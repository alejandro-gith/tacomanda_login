using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Tacomanda.Api;
using Tacomanda.Api.Middleware;
using Tacomanda.Application;
using Tacomanda.Domain;
using Tacomanda.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var logger = context.HttpContext.RequestServices
                .GetRequiredService<ILoggerFactory>()
                .CreateLogger("Validation");

            logger.LogWarning(
                "Invalid request for {Path}: {@Errors}",
                context.HttpContext.Request.Path,
                context.ModelState);

            return new BadRequestObjectResult(new
            {
                status = 400,
                message = "Error en el sistema."
            });
        };
    });
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()));

var signingKey = builder.Configuration["Jwt:SigningKey"]
    ?? throw new InvalidOperationException("Jwt:SigningKey is required.");

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(signingKey)),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30)
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                context.HttpContext.RequestServices
                    .GetRequiredService<ILoggerFactory>()
                    .CreateLogger("Authentication")
                    .LogWarning(context.Exception, "JWT authentication failed.");

                return Task.CompletedTask;
            }
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddSingleton<IPasswordService, Pbkdf2PasswordService>();
builder.Services.AddSingleton<InMemoryDatabase>();
builder.Services.AddSingleton<IEmployeeRepository>(
    sp => sp.GetRequiredService<InMemoryDatabase>());
builder.Services.AddSingleton<IDishRepository>(
    sp => sp.GetRequiredService<InMemoryDatabase>());
builder.Services.AddSingleton<ITableRepository>(
    sp => sp.GetRequiredService<InMemoryDatabase>());
builder.Services.AddSingleton<IOrderRepository>(
    sp => sp.GetRequiredService<InMemoryDatabase>());
builder.Services.AddSingleton<ITokenService, JwtTokenService>();

builder.Services.AddScoped<IValidator<LoginCommand>, LoginCommandValidator>();
builder.Services.AddScoped<IValidator<CreateOrderCommand>, CreateOrderCommandValidator>();

builder.Services.AddScoped<
    IQueryHandler<GetAvailableUsersQuery, IReadOnlyList<AvailableUserDto>>,
    GetAvailableUsersHandler>();
builder.Services.AddScoped<ICommandHandler<LoginCommand, SessionDto>, LoginCommandHandler>();
builder.Services.AddScoped<
    IQueryHandler<ListDishesQuery, IReadOnlyList<DishDto>>,
    ListDishesHandler>();
builder.Services.AddScoped<
    IQueryHandler<ListTablesQuery, IReadOnlyList<TableDto>>,
    ListTablesHandler>();
builder.Services.AddScoped<
    ICommandHandler<CreateOrderCommand, OrderDto>,
    CreateOrderCommandHandler>();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;
    var logger = context.HttpContext.RequestServices
        .GetRequiredService<ILoggerFactory>()
        .CreateLogger("HttpStatus");

    logger.LogWarning(
        "Request returned {StatusCode}: {Method} {Path}",
        response.StatusCode,
        context.HttpContext.Request.Method,
        context.HttpContext.Request.Path);

    response.ContentType = "application/problem+json";
    await response.WriteAsJsonAsync(new
    {
        status = response.StatusCode,
        message = "Error en el sistema."
    });
});
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/api/health", () => Results.Ok(new { status = "ok" }))
    .AllowAnonymous();
app.Run();

public partial class Program { }
