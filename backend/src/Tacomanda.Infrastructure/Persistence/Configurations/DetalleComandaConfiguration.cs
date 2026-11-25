using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tacomanda.Domain.Comandas;
using Tacomanda.Domain.Platillos;

namespace Tacomanda.Infrastructure.Persistence.Configurations;

public sealed class DetalleComandaConfiguration : IEntityTypeConfiguration<DetalleComanda>
{
    public void Configure(EntityTypeBuilder<DetalleComanda> builder)
    {
        builder.ToTable("detalle_comanda");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id_detalle").ValueGeneratedOnAdd();
        builder.Property<int>("ComandaId").HasColumnName("id_comanda");
        builder.Property(d => d.PlatilloId).HasColumnName("id_platillo");
        builder.Property(d => d.Nombre).HasColumnName("nombre").HasMaxLength(50);
        builder.Property(d => d.PrecioUnitario).HasColumnName("precio_unitario").HasPrecision(8, 2);
        builder.Property(d => d.Cantidad).HasColumnName("cantidad");
        builder.Property(d => d.Observaciones).HasColumnName("nota").HasMaxLength(200);
        builder.Property(d => d.Subtotal).HasColumnName("subtotal").HasPrecision(8, 2);
        builder.HasOne<Platillo>().WithMany().HasForeignKey(d => d.PlatilloId);
    }
}
