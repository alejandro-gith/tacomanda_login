using Microsoft.EntityFrameworkCore;
using Tacomanda.Domain.Empleados;
using Tacomanda.Infrastructure.Seed;

namespace Tacomanda.Infrastructure.Persistence.Repositories;

public sealed class DatosDePruebaRepository : IDatosDePruebaRepository
{
    private readonly TacomandaDbContext _context;

    public DatosDePruebaRepository(TacomandaDbContext context)
    {
        _context = context;
    }

    public Task<bool> ExistenAsync(CancellationToken cancellationToken)
    {
        return _context.Set<Empleado>().AnyAsync(cancellationToken);
    }

    public async Task GuardarAsync(IReadOnlyCollection<Empleado> empleados, CancellationToken cancellationToken)
    {
        _context.Set<Empleado>().AddRange(empleados);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
