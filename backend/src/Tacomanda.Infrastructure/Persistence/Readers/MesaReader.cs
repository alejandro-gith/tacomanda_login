using Tacomanda.Application.ConsultarMesas;
using Tacomanda.Domain.Mesas;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Infrastructure.Persistence.Readers;

public sealed class MesaReader : IMesaReader
{
    private readonly IMesasLecturaRepository _repository;

    public MesaReader(IMesasLecturaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<Mesa>> LeerAsync(CancellationToken cancellationToken)
    {
        return await _repository.ListarAsync(cancellationToken);
    }
}
