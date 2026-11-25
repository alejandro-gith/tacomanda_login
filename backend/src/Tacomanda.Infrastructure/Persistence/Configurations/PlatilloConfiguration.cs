using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tacomanda.Domain.Platillos;

namespace Tacomanda.Infrastructure.Persistence.Configurations;

public sealed class PlatilloConfiguration : IEntityTypeConfiguration<Platillo>
{
    public void Configure(EntityTypeBuilder<Platillo> builder)
    {
        builder.ToTable("platillos");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id_platillo").ValueGeneratedOnAdd();
        builder.Property(p => p.Nombre).HasColumnName("nombre").HasMaxLength(50).IsRequired();
        builder.Property(p => p.Categoria).HasColumnName("categoria").HasMaxLength(25).IsRequired();
        builder.Property(p => p.Descripcion).HasColumnName("descripcion").HasMaxLength(100).IsRequired();
        builder.Property(p => p.Precio).HasColumnName("precio").HasPrecision(8, 2);
        builder.Property(p => p.Emoji).HasColumnName("emoji").HasMaxLength(8).IsRequired();
        builder.Property(p => p.Activo).HasColumnName("activo");
    }
}
