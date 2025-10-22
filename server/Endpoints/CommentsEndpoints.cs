using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs;
using server.Models;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace server.Endpoints
{
    public static class CommentsEndpoints
    {
        public static IEndpointRouteBuilder MapComments(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/comments").WithTags("Comments");

            group.MapPost("create", async ([FromServices] DataContext context
                ,HttpContext httpContext,
                string content, string? profission = null
            ) =>
            { 

                var claims = httpContext.User;
                if (claims?.Identity?.IsAuthenticated != true)
                    return Results.Unauthorized();

                var id = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new ArgumentNullException("User não autenticado");

                var user = await context.Users.FirstOrDefaultAsync(u => u.Id.ToString() == id) ?? throw new ArgumentNullException("User não autenticado");

                if (user.Profission is null && !string.IsNullOrWhiteSpace(profission))
                    user.Profission = profission;

                var comment = new Comment
                {
                    User = user,
                    Content = content,
                    UserId = user.Id
                };

                await context.AddAsync(comment);
                await context.SaveChangesAsync();

                return Results.Ok("Comentário adicionado");

            }).RequireAuthorization();


            group.MapPost("like", async (DataContext context, HttpContext httpContext, Guid commentId) =>
            {
                var claims = httpContext.User;
                if (claims?.Identity?.IsAuthenticated != true)
                    return Results.Unauthorized();

                var id = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new ArgumentNullException("User não autenticado");

                var user = await context.Users.FirstOrDefaultAsync(u => u.Id.ToString() == id) ?? throw new ArgumentNullException("User não autenticado");

                var comment = await context.Comments.FirstOrDefaultAsync(c => c.Id == commentId) ?? throw new ArgumentNullException("Comentário curtido não extiste");

                var commentLike = new CommentLike
                {
                    User = user,
                    UserId = user.Id,
                    Comment = comment,
                    CommentId = comment.Id,
                    CreatedAt = DateTime.UtcNow
                };

                await context.CommentLikes.AddAsync(commentLike);
                await context.SaveChangesAsync();

                return Results.Ok("Like Adicionado");
            });

            group.MapGet("Listar", async (DataContext context,int page) =>
            {
                if (page < 1) page = 1;
                const int pageSize = 4;


                var comments = await context.Comments
                    .Include(c => c.User)
                    .Include(c => c.CommentLikes)
                    .Select(c => new CommentDTO
                    {
                        Id = c.Id,
                        Content = c.Content,
                        LikesCount = c.CommentLikes.Count,
                        UserName = c.User.Name,
                        CreatedAt = c.CreatedAt,
                        UserPhotoUrl = c.User.PhotoUrl,
                        TimeAgo = DateTime.UtcNow - c.CreatedAt
                    })
                    .OrderBy(c => c.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();


                return Results.Ok(comments);
            });

            group.MapGet("GetComments", async (DataContext context, HttpContext httpContext, int page) =>
            {

                if (httpContext?.User?.Identity?.IsAuthenticated == false)
                    return Results.Unauthorized();

                var id = httpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new ArgumentNullException("User não autenticado");

                if (page < 1) page = 1;
                const int pageSize = 4;

                var comments = await context.Comments
                 .Include(c => c.User)
                 .Include(c => c.CommentLikes)
                 .Select(c => new CommentDTO
                 {
                     Id = c.Id,
                     Content = c.Content,
                     LikesCount = c.CommentLikes.Count,
                     UserName = c.User.Name,
                     CreatedAt = c.CreatedAt,
                     UserPhotoUrl = c.User.PhotoUrl,
                     TimeAgo = DateTime.UtcNow - c.CreatedAt,
                     LikedByCurrentUser = c.CommentLikes.FirstOrDefault(l => l.UserId.ToString() == id && l.CommentId == c.Id) != null ? true : false 
                 })
                  .OrderBy(c => c.Id)
                  .Skip((page - 1) * pageSize)
                  .Take(pageSize)
                  .ToListAsync();
                var totalItems = await context.Comments.CountAsync();
                var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

                return Results.Ok(comments);

            }).RequireAuthorization();

            group.MapGet("/getPages", async (DataContext context) =>
            {
                const int pageSize = 4;
                var totalItems = await context.Comments.CountAsync();
                var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

                return Results.Ok(totalPages);
            });

            return builder;
        }
    }
}
