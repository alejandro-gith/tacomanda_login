using Tacomanda.Domain.Interfaces;
using RetroalimentacionEntidad = Tacomanda.Domain.Retroalimentacion.Retroalimentacion;

namespace Tacomanda.Infrastructure.Persistence.Repositories;

public sealed class RetroalimentacionRepository : IRetroalimentacionRepository
{
    private readonly TacomandaDbContext _context;
    public RetroalimentacionRepository(TacomandaDbContext context) { _context = context; }
    public void Agregar(RetroalimentacionEntidad retroalimentacion) { _context.Set<RetroalimentacionEntidad>().Add(retroalimentacion); }
}
