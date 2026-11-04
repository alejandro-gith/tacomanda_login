using Tacomanda.Domain.Empleados;

namespace Tacomanda.Domain.Interfaces;

public interface IEmpleadoRepository
{
    Task<Empleado?> BuscarPorUsuarioAsync(string usuario, CancellationToken cancellationToken);
}
