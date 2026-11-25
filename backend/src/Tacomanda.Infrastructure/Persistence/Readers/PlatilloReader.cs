using Tacomanda.Application.ConsultarPlatillo;
using Tacomanda.Domain.Platillos;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Infrastructure.Persistence.Readers;

public sealed class PlatilloReader : IPlatilloReader
{
    private readonly IPlatillosLecturaRepository _repository;

    public PlatilloReader(IPlatillosLecturaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<Platillo>> LeerAsync(CancellationToken cancellationToken)
    {
        return await _repository.ListarAsync(cancellationToken);
    }
}
