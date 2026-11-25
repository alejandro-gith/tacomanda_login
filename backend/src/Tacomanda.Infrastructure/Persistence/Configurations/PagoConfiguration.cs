using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tacomanda.Domain.Comandas;
using Tacomanda.Domain.Pagos;

namespace Tacomanda.Infrastructure.Persistence.Configurations;

public sealed class PagoConfiguration : IEntityTypeConfiguration<Pago>
{
    public void Configure(EntityTypeBuilder<Pago> builder)
    {
        builder.ToTable("pedidos");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id_pedido").ValueGeneratedOnAdd();
        builder.Property(p => p.ComandaId).HasColumnName("id_comanda");
        builder.Property(p => p.Forma).HasColumnName("tipo_pago").HasMaxLength(20);
        builder.Property(p => p.TipoPedido).HasColumnName("tipo_pedido").HasMaxLength(20);
        builder.Property(p => p.Monto).HasColumnName("monto").HasPrecision(8, 2);
        builder.Property(p => p.Cambio).HasColumnName("cambio").HasPrecision(8, 2);
        builder.Property(p => p.Propina).HasColumnName("propina").HasPrecision(8, 2);
        builder.Property(p => p.Fecha).HasColumnName("fecha")
            .HasConversion(value => value.UtcDateTime, value => new DateTimeOffset(DateTime.SpecifyKind(value, DateTimeKind.Utc)));
        builder.Property(p => p.EmpleadoId).HasColumnName("no_control");
        builder.HasIndex(p => p.ComandaId).IsUnique();
        builder.HasOne<Comanda>().WithOne().HasForeignKey<Pago>(p => p.ComandaId);
    }
}
