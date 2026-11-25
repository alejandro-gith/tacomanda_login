using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Tacomanda.Application.Seguridad;
using Tacomanda.Domain.Empleados;

namespace Tacomanda.Infrastructure.Seguridad;

public sealed class JwtTokenService : ITokenService
{
    private readonly JwtSettings _settings;

    public JwtTokenService(JwtSettings settings)
    {
        _settings = settings;
    }

    public TokenDto Generar(Empleado empleado)
    {
        DateTimeOffset expira = DateTimeOffset.UtcNow.AddHours(8);

        Claim[] claims =
        {
            new Claim(JwtRegisteredClaimNames.Sub, empleado.Id.ToString()),
            new Claim("role", empleado.Rol.ToString()),
            new Claim("name", empleado.Nombre),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        SigningCredentials firma = new(
            new SymmetricSecurityKey(_settings.SigningKey),
            SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new(
            _settings.Issuer,
            _settings.Audience,
            claims,
            expires: expira.UtcDateTime,
            signingCredentials: firma);

        return new TokenDto(new JwtSecurityTokenHandler().WriteToken(token), expira);
    }
}
