using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Tacomanda.Api.Configuration;
using Tacomanda.Api.Mapping;
using Tacomanda.Api.Middleware;
using Tacomanda.Api.Seguridad;
using Tacomanda.Application;
using Tacomanda.Application.Seguridad;
using Tacomanda.Infrastructure;
using Tacomanda.Infrastructure.Seed;
using Tacomanda.Infrastructure.Seguridad;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddAuthorization();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

string? jwtSecret = builder.Configuration["Jwt:Key"];
if (!builder.Environment.IsDevelopment() && string.IsNullOrWhiteSpace(jwtSecret))
    throw new InvalidOperationException("Configure Jwt:Key para ejecutar fuera de Development.");
builder.Services.AddSingleton(new JwtSettings("Tacomanda", "Tacomanda.Angular", jwtSecret));
builder.Services.AddSingleton<IConfigureOptions<JwtBearerOptions>, JwtBearerConfiguration>();
builder.Services.AddSingleton<IConfigureOptions<ApiBehaviorOptions>, ApiBehaviorConfiguration>();
builder.Services.AddSingleton<IConfigureOptions<CorsOptions>, CorsConfiguration>();
builder.Services.AddScoped<IUsuarioActual, UsuarioActual>();
builder.Services.AddScoped<ICrearComandaCommandFactory, CrearComandaCommandFactory>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using IServiceScope scope = app.Services.CreateScope();
    DatosDePrueba datos = scope.ServiceProvider.GetRequiredService<DatosDePrueba>();
    await datos.InicializarAsync(CancellationToken.None);
}
else
{
    using IServiceScope scope = app.Services.CreateScope();
    BootstrapAdmin bootstrap = scope.ServiceProvider.GetRequiredService<BootstrapAdmin>();
    await bootstrap.InicializarAsync(CancellationToken.None);
}

app.UseMiddleware<RegistroHttpMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePages(StatusCodeResponder.ResponderAsync);
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
