using Microsoft.EntityFrameworkCore;
using server.Data;

namespace server.Endpoints
{
    public static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/getMe", async (DataContext context, HttpContext httpContext) =>
            {
                var auth = httpContext?.User?.Identity?.IsAuthenticated ?? false;
                if (!auth)
                    return Results.Unauthorized();

                var id = httpContext?.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? throw new Exception("Not Found");

                var user = await context.Users
                    .Where(u => u.Id.ToString() == id)
                    .Select(u => new
                    {
                        u.Id,
                        u.Name,
                        u.Email,
                        u.PhotoUrl,
                        u.Profission
                    })
                    .FirstOrDefaultAsync();
                if (user is null)
                    return Results.NotFound(new { Message = "User not found." });
                return Results.Ok(user);
            }).RequireAuthorization();
            return app;
        }
    }
}
