using Tacomanda.Domain.Empleados;

namespace Tacomanda.Domain.Interfaces;

public interface IMeseroReader
{
    Task<Empleado?> BuscarPorIdAsync(int id, CancellationToken cancellationToken);
}
