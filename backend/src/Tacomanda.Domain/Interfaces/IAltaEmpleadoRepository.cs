using Tacomanda.Domain.Empleados;

namespace Tacomanda.Domain.Interfaces;

public interface IAltaEmpleadoRepository
{
    void Agregar(Empleado empleado);
}
