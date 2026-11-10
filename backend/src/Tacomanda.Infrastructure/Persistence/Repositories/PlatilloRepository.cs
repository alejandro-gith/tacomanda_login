using Tacomanda.Domain.Platillos;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Infrastructure.Persistence.Repositories;

public sealed class PlatilloRepository : IPlatilloRepository, IPlatillosEscrituraRepository
{
    private readonly TacomandaDbContext _context;

    public PlatilloRepository(TacomandaDbContext context)
    {
        _context = context;
    }

    public async Task<Platillo?> ObtenerAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<Platillo>().FindAsync(new object[] { id }, cancellationToken);
    }

    public void Agregar(Platillo platillo)
    {
        _context.Set<Platillo>().Add(platillo);
    }
}
