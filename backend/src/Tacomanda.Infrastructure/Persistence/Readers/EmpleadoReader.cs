using Tacomanda.Application.ConsultarUsuarios;
using Tacomanda.Domain.Empleados;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Infrastructure.Persistence.Readers;

public sealed class EmpleadoReader : IEmpleadoReader
{
    private readonly IEmpleadosLecturaRepository _repository;

    public EmpleadoReader(IEmpleadosLecturaRepository repository)
    {
        _repository = repository;
    }

    public Task<IReadOnlyList<Empleado>> ListarActivosAsync(CancellationToken cancellationToken) =>
        _repository.ListarActivosAsync(cancellationToken);
}
