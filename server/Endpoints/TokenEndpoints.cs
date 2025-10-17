using AuthLibrary.Services;
using Microsoft.EntityFrameworkCore;
using server.Data;

namespace server.Endpoints
{
    public static class TokenEndpoints
    {
        public static void MapTokensEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/tokens");

            group.MapGet("/acessToken",async (DataContext context, HttpContext httpContext, ITokenService tokenService) =>
            {
                var cookie = httpContext.Request.Cookies["RefreshToken"];
                if(cookie is null)
                {
                    return Results.Unauthorized();
                }
                var refreshToken = await context.UserLogins.Include(c => c.User)
                .SingleOrDefaultAsync(c => c.Token == cookie) ?? throw new Exception("Erro, refresh token is null");
                Console.WriteLine("RefreshToken :" + refreshToken);
                List<string> roles = ["user"];
                var token = tokenService.GenerateToken(refreshToken.User, roles);

                return Results.Ok(token);
            });
        }
    }
}
