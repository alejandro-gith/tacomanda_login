using System.Security.Claims;
using Tacomanda.Application.Seguridad;

namespace Tacomanda.Api.Seguridad;

public sealed class UsuarioActual : IUsuarioActual
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UsuarioActual(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int ObtenerId()
    {
        ClaimsPrincipal? usuario = _httpContextAccessor.HttpContext?.User;
        if (usuario?.Identity?.IsAuthenticated != true ||
            !int.TryParse(usuario.FindFirstValue("sub"), out int id) || id <= 0)
        {
            throw new UnauthorizedAccessException("La identidad autenticada es inválida.");
        }

        return id;
    }

    public string ObtenerRol()
    {
        ClaimsPrincipal? usuario = _httpContextAccessor.HttpContext?.User;
        if (usuario?.Identity?.IsAuthenticated != true || usuario.FindFirstValue("role") is not string rol)
        {
            throw new UnauthorizedAccessException("La identidad autenticada es inválida.");
        }
        return rol;
    }
}
