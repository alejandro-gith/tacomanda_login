using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tacomanda.Domain.Mesas;

namespace Tacomanda.Infrastructure.Persistence.Configurations;

public sealed class MesaConfiguration : IEntityTypeConfiguration<Mesa>
{
    public void Configure(EntityTypeBuilder<Mesa> builder)
    {
        builder.ToTable("Mesas");
        builder.HasKey(nameof(Mesa.Id));
        builder.Property(nameof(Mesa.Version)).IsConcurrencyToken();
    }
}
