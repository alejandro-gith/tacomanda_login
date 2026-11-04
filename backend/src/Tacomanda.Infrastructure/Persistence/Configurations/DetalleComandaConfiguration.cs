using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tacomanda.Domain.Comandas;

namespace Tacomanda.Infrastructure.Persistence.Configurations;

public sealed class DetalleComandaConfiguration : IEntityTypeConfiguration<DetalleComanda>
{
    public void Configure(EntityTypeBuilder<DetalleComanda> builder)
    {
        builder.ToTable("DetallesComanda");
        builder.HasKey(nameof(DetalleComanda.Id));
        builder.Ignore(nameof(DetalleComanda.Subtotal));
        builder.HasOne<Tacomanda.Domain.Platillos.Platillo>()
            .WithMany().HasForeignKey(nameof(DetalleComanda.PlatilloId));
    }
}
