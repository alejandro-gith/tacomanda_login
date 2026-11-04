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

    public Guid ObtenerId()
    {
        ClaimsPrincipal? usuario = _httpContextAccessor.HttpContext?.User;
        if (usuario?.Identity?.IsAuthenticated != true ||
            !Guid.TryParse(usuario.FindFirstValue("sub"), out Guid id) || id == Guid.Empty)
        {
            throw new UnauthorizedAccessException("La identidad autenticada es inválida.");
        }

        return id;
    }
}
