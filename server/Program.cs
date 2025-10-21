using AuthLibrary.Extensions;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Endpoints;
using server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

//Adiciona o Swagger com autenticação
builder.Services.AddSwaggerAuth("Api SG Design", "v1", "api feita para a SG Design Consumir");
builder.Services.AddTokenService(key: "jebjkmdp90jijwdkjqhqkdvy5632849riiojbdbt737ydh92idjwkdhqdjh");
builder.Services.AddAuthSuporte("jebjkmdp90jijwdkjqhqkdvy5632849riiojbdbt737ydh92idjwkdhqdjh", "353535077307-nqv0s4rge8nh5d3a9eklcoacdijk61hf.apps.googleusercontent.com", "YOU");

// Add CORS policy to allow requests from any origin
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."))
);

builder.Services.AddHttpClient();
builder.Services.AddScoped<ICookieGenerate, CookieGenerateService>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();


app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.MapUserAuth();

app.MapComments();

app.MapTokensEndpoints();

app.Run();
