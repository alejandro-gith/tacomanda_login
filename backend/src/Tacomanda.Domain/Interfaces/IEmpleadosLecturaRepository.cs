using Tacomanda.Domain.Empleados;

namespace Tacomanda.Domain.Interfaces;

public interface IEmpleadosLecturaRepository
{
    Task<IReadOnlyList<Empleado>> ListarActivosAsync(CancellationToken cancellationToken);
}
