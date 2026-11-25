using Microsoft.EntityFrameworkCore;
using Tacomanda.Domain.Mesas;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Infrastructure.Persistence.Repositories;

public sealed class MesasLecturaRepository : IMesasLecturaRepository
{
    private readonly TacomandaDbContext _context;

    public MesasLecturaRepository(TacomandaDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Mesa>> ListarAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<Mesa>()
            .AsNoTracking().ToListAsync(cancellationToken);
    }
}
