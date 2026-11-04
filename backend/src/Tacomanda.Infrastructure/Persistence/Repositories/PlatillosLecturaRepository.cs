using Microsoft.EntityFrameworkCore;
using Tacomanda.Domain.Platillos;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Infrastructure.Persistence.Repositories;

public sealed class PlatillosLecturaRepository : IPlatillosLecturaRepository
{
    private readonly TacomandaDbContext _context;

    public PlatillosLecturaRepository(TacomandaDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Platillo>> ListarAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<Platillo>()
            .AsNoTracking().ToListAsync(cancellationToken);
    }
}
