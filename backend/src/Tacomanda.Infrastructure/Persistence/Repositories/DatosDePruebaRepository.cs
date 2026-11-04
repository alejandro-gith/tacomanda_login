using Microsoft.EntityFrameworkCore;
using Tacomanda.Domain.Empleados;
using Tacomanda.Domain.Mesas;
using Tacomanda.Domain.Platillos;
using Tacomanda.Infrastructure.Seed;

namespace Tacomanda.Infrastructure.Persistence.Repositories;

public sealed class DatosDePruebaRepository : IDatosDePruebaRepository
{
    private readonly TacomandaDbContext _context;

    public DatosDePruebaRepository(TacomandaDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistenAsync(CancellationToken cancellationToken)
    {
        await _context.Database.EnsureCreatedAsync(cancellationToken);
        return await _context.Set<Empleado>().AnyAsync(cancellationToken);
    }

    public async Task GuardarAsync(
        IReadOnlyCollection<Empleado> empleados,
        IReadOnlyCollection<Mesa> mesas,
        IReadOnlyCollection<Platillo> platillos,
        CancellationToken cancellationToken)
    {
        _context.Set<Empleado>().AddRange(empleados);
        _context.Set<Mesa>().AddRange(mesas);
        _context.Set<Platillo>().AddRange(platillos);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
