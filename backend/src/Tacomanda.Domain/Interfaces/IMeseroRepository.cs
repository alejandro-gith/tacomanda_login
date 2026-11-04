using Tacomanda.Domain.Empleados;

namespace Tacomanda.Domain.Interfaces;

public interface IMeseroRepository
{
    Task<Empleado?> ObtenerAsync(Guid id, CancellationToken cancellationToken);
}
