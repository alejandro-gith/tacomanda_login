using Tacomanda.Domain.Comandas;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Infrastructure.Persistence.Readers;

public sealed class ComandaReader : IComandaReader
{
    private readonly IComandasLecturaRepository _repository;

    public ComandaReader(IComandasLecturaRepository repository)
    {
        _repository = repository;
    }

    public Task<Comanda?> ObtenerAsync(int id, CancellationToken ct) =>
        _repository.ObtenerAsync(id, ct);

    public Task<IReadOnlyList<Comanda>> ListarAsync(int? meseroId, OrderStatus? estado,
        bool soloCocina, CancellationToken ct) =>
        _repository.ListarAsync(meseroId, estado, soloCocina, ct);
}
