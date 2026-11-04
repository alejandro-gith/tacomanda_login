using Tacomanda.Domain.Mesas;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Infrastructure.Persistence.Repositories;

public sealed class MesaRepository : IMesaRepository
{
    private readonly TacomandaDbContext _context;

    public MesaRepository(TacomandaDbContext context)
    {
        _context = context;
    }

    public async Task<Mesa?> ObtenerAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<Mesa>().FindAsync(new object[] { id }, cancellationToken);
    }
}
