using AuthLibrary.Services;
using Google;
using Google.Apis.Auth;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Endpoints
{
    public static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUserAuth(this IEndpointRouteBuilder app)
        {
            app.MapPost("/google", async (DataContext context, ITokenService tokenService, string IdToken) =>
            {

                try
                {
                    var settings = new GoogleJsonWebSignature.ValidationSettings()
                    {
                        Audience = new[] { "353535077307-nqv0s4rge8nh5d3a9eklcoacdijk61hf.apps.googleusercontent.com" }
                    };

                    var payload = await GoogleJsonWebSignature.ValidateAsync(IdToken, settings);

                    var user = await context.Users.FirstOrDefaultAsync(u => u.Email == payload.Email);

                    if (user is null)
                    {
                        user = new User
                        {
                            Email = payload.Email,
                            Name = payload.Name,
                            PhotoUrl = payload.Picture,
                        };
                        await context.Users.AddAsync(user);
                    }
                    else
                    {
                        user.Name = payload.Name;
                        user.PhotoUrl = payload.Picture;
                        context.Users.Update(user);
                    }

                    await context.SaveChangesAsync();

                    List<string> roles = ["user"];

                    var token = tokenService.GenerateToken(user, roles);


                    return Results.Ok(token);
                }
                catch (GoogleApiException ex)
                {
                    Console.WriteLine("Ocorreu uma exceção ao fazer o login com google" + ex.Message);
                    return Results.BadRequest("Erro interno do servidor");
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu uma exceção ao fazer o login com google" + ex.Message);
                    return Results.BadRequest("Erro interno do servidor");
                }
            });

            return app;
        }
    }
}