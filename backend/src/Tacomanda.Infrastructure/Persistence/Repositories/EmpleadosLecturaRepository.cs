using Microsoft.EntityFrameworkCore;
using Tacomanda.Domain.Empleados;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Infrastructure.Persistence.Repositories;

public sealed class EmpleadosLecturaRepository : IEmpleadosLecturaRepository
{
    private readonly TacomandaDbContext _context;

    public EmpleadosLecturaRepository(TacomandaDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Empleado>> ListarActivosAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<Empleado>().AsNoTracking()
            .Where(e => e.Activo).OrderBy(e => e.Nombre).ToListAsync(cancellationToken);
    }
}
