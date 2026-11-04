using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tacomanda.Domain.Platillos;

namespace Tacomanda.Infrastructure.Persistence.Configurations;

public sealed class PlatilloConfiguration : IEntityTypeConfiguration<Platillo>
{
    public void Configure(EntityTypeBuilder<Platillo> builder)
    {
        builder.ToTable("Platillos");
        builder.HasKey(nameof(Platillo.Id));
    }
}
