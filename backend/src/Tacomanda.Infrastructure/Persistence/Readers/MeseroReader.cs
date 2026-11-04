using Tacomanda.Domain.Empleados;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Infrastructure.Persistence.Readers;

public sealed class MeseroReader : IMeseroReader
{
    private readonly IMeseroRepository _repository;

    public MeseroReader(IMeseroRepository repository)
    {
        _repository = repository;
    }

    public async Task<Empleado?> BuscarPorIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _repository.ObtenerAsync(id, cancellationToken);
    }
}
