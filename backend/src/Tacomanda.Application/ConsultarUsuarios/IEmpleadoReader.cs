using Tacomanda.Domain.Empleados;

namespace Tacomanda.Application.ConsultarUsuarios;

public interface IEmpleadoReader
{
    Task<IReadOnlyList<Empleado>> ListarActivosAsync(CancellationToken cancellationToken);
}
