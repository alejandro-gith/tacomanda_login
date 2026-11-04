using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tacomanda.Domain.Empleados;

namespace Tacomanda.Infrastructure.Persistence.Configurations;

public sealed class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("Empleados");
        builder.HasKey(nameof(Empleado.Id));
        builder.HasIndex(nameof(Empleado.Usuario)).IsUnique();
    }
}
