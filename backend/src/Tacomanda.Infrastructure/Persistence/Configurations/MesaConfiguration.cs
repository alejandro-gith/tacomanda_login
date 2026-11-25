using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tacomanda.Domain.Mesas;

namespace Tacomanda.Infrastructure.Persistence.Configurations;

public sealed class MesaConfiguration : IEntityTypeConfiguration<Mesa>
{
    public void Configure(EntityTypeBuilder<Mesa> builder)
    {
        builder.ToTable("mesas");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(m => m.Numero).HasColumnName("numero");
        builder.HasIndex(m => m.Numero).IsUnique();
        builder.Property(m => m.Estado).HasColumnName("estado").HasMaxLength(10);
        builder.Property(m => m.Version).HasColumnName("version").IsConcurrencyToken();
        builder.Ignore(m => m.Nombre);
        builder.Ignore(m => m.Disponible);
    }
}
