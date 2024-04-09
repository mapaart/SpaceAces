using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SpacecapsCase.Application.Interfaces;
using SpacecapsCase.Application.Services;
using SpacecapsCase.Domain.Interfaces;
using SpacecapsCase.Domain.Mappers;
using SpacecapsCase.Domain.Middleware;
using SpacecapsCase.Domain.UseCases;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IUsuarioUseCase, UsuarioUseCaseIImpl>();
builder.Services.AddScoped<ILoginUseCase, LoginUseCaseImpl>();
builder.Services.AddScoped<ITarefaUseCase, TarefaUseCaseImpl>();
builder.Services.AddScoped<IHttpHeaderService, HttpHeaderService>();
builder.Services.AddAutoMapper(typeof(UsuarioMapper));
builder.Services.AddAutoMapper(typeof(TarefaMapper));

var configuration = builder.Configuration;

//JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["Jwt:Issuer"],
        ValidAudience = configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseMiddleware<ExceptionHandlerMiddleware>();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
