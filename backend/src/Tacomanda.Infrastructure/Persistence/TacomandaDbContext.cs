using Microsoft.EntityFrameworkCore;
using Tacomanda.Domain.Comandas;
using Tacomanda.Domain.Empleados;
using Tacomanda.Domain.Mesas;
using Tacomanda.Domain.Platillos;
using Tacomanda.Infrastructure.Persistence.Configurations;

namespace Tacomanda.Infrastructure.Persistence;

public sealed class TacomandaDbContext : DbContext
{
    public TacomandaDbContext(DbContextOptions<TacomandaDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmpleadoConfiguration());
        modelBuilder.ApplyConfiguration(new MesaConfiguration());
        modelBuilder.ApplyConfiguration(new PlatilloConfiguration());
        modelBuilder.ApplyConfiguration(new ComandaConfiguration());
        modelBuilder.ApplyConfiguration(new DetalleComandaConfiguration());
    }

}
