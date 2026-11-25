using Tacomanda.Domain.Empleados;

namespace Tacomanda.Application.Seguridad;

public interface ITokenService
{
    TokenDto Generar(Empleado empleado);
}
