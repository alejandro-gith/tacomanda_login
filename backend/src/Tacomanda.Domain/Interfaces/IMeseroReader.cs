using Tacomanda.Domain.Empleados;

namespace Tacomanda.Domain.Interfaces;

public interface IMeseroReader
{
    Task<Empleado?> BuscarPorIdAsync(Guid id, CancellationToken cancellationToken);
}
