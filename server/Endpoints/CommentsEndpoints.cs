using Microsoft.AspNetCore.Mvc;
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
            var group = builder.MapGroup("/comments");

            group.MapPost("create", async ([FromServices] DataContext context
                ,HttpContext httpContext,
                string content
            ) =>
            {
                var claims = httpContext.User;
                if (claims?.Identity?.IsAuthenticated != true)
                    return Results.Unauthorized();

                var id = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new ArgumentNullException("User não autenticado");

                var user = await context.Users.FirstOrDefaultAsync(u => u.Id.ToString() == id) ?? throw new ArgumentNullException("User não autenticado");
                    
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

            group.MapGet("Listar", async (DataContext context) =>
            {
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
                    .ToListAsync();

                return comments;
            });

            return builder;
        }
    }
}
