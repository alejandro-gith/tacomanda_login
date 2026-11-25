using Tacomanda.Domain.Comandas;

namespace Tacomanda.Domain.Interfaces;

public interface IComandasLecturaRepository
{
    Task<Comanda?> ObtenerAsync(int id, CancellationToken ct);
    Task<IReadOnlyList<Comanda>> ListarAsync(int? meseroId, OrderStatus? estado, bool soloCocina, CancellationToken ct);
}
