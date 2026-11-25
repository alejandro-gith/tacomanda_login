using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tacomanda.Domain.Empleados;

namespace Tacomanda.Infrastructure.Persistence.Configurations;

public sealed class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("empleados");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("no_control").ValueGeneratedOnAdd();
        builder.Property(e => e.Usuario).HasColumnName("usuario").HasMaxLength(80).IsRequired();
        builder.HasIndex(e => e.Usuario).IsUnique();
        builder.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();
        builder.Property(e => e.PasswordHash).HasColumnName("contrasena").HasMaxLength(255).IsRequired();
        builder.Property(e => e.Activo).HasColumnName("activo");
        builder.Property(e => e.Rol).HasColumnName("tipo_empleado").HasMaxLength(10)
            .HasConversion(
                role => role == EmployeeRole.Administrador ? "admin" :
                    role == EmployeeRole.Mesero ? "mesero" :
                    role == EmployeeRole.Cajero ? "cajero" : "cocina",
                value => value == "admin" ? EmployeeRole.Administrador :
                    value == "mesero" ? EmployeeRole.Mesero :
                    value == "cajero" ? EmployeeRole.Cajero : EmployeeRole.Cocinero);
    }
}
