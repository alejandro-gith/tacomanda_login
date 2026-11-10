using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tacomanda.Domain.Comandas;

namespace Tacomanda.Infrastructure.Persistence.Configurations;

public sealed class ComandaConfiguration : IEntityTypeConfiguration<Comanda>
{
    public void Configure(EntityTypeBuilder<Comanda> builder)
    {
        builder.ToTable("Comandas");
        builder.HasKey(nameof(Comanda.Id));
        builder.Ignore(nameof(Comanda.Total));
        builder.HasOne<Tacomanda.Domain.Mesas.Mesa>()
            .WithMany().HasForeignKey(nameof(Comanda.MesaId));
        builder.HasOne<Tacomanda.Domain.Empleados.Empleado>()
            .WithMany().HasForeignKey(nameof(Comanda.MeseroId));
        builder.HasMany<DetalleComanda>(nameof(Comanda.Detalles))
            .WithOne().HasForeignKey("ComandaId").IsRequired();
        builder.Navigation(nameof(Comanda.Detalles))
            .HasField("_detalles").UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
