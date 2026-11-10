using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Tacomanda.Infrastructure.Seguridad;

namespace Tacomanda.Api.Configuration;

public sealed class JwtBearerConfiguration : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly JwtSettings _settings;

    public JwtBearerConfiguration(JwtSettings settings)
    {
        _settings = settings;
    }

    public void Configure(JwtBearerOptions options)
    {
        Configure(JwtBearerDefaults.AuthenticationScheme, options);
    }

    public void Configure(string? name, JwtBearerOptions options)
    {
        if (name != JwtBearerDefaults.AuthenticationScheme)
        {
            return;
        }

        options.MapInboundClaims = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = _settings.Issuer,
            ValidateAudience = true,
            ValidAudience = _settings.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(_settings.SigningKey),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30),
            NameClaimType = "name",
            RoleClaimType = "role"
        };
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = ValidarIdentificadorAsync
        };
    }

    private static Task ValidarIdentificadorAsync(TokenValidatedContext context)
    {
        if (!Guid.TryParse(context.Principal?.FindFirstValue("sub"), out Guid id) ||
            id == Guid.Empty)
        {
            context.Fail("El token no contiene un identificador válido.");
        }
        return Task.CompletedTask;
    }
}
