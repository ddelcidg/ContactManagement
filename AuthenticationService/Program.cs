using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using AuthenticationService.Application.Interfaces;
using AuthenticationService.Application.Services;
using AuthenticationService.Domain.Interfaces;
using AuthenticationService.Domain.Services;
using AuthenticationService.Infrastructure.Data;
using AuthenticationService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configurar DbContext con SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyección de dependencias para repositorios y servicios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<PasswordHasher>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService.Application.Services.AuthenticationService>();

// Configurar MediatR para CQRS
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

// Agregar controladores
builder.Services.AddControllers();

// Agregar Swagger para la documentación de la API (opcional)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
    builder.WithOrigins("http://localhost:4200")
           .AllowAnyHeader()
           .AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
