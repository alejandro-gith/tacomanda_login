using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tacomanda.Domain.Empleados;
using Tacomanda.Domain.Retroalimentacion;

namespace Tacomanda.Infrastructure.Persistence.Configurations;

public sealed class RetroalimentacionConfiguration : IEntityTypeConfiguration<Retroalimentacion>
{
    public void Configure(EntityTypeBuilder<Retroalimentacion> builder)
    {
        builder.ToTable("retroalimentacion_app");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).HasColumnName("id_retro").ValueGeneratedOnAdd();
        builder.Property(r => r.EmpleadoId).HasColumnName("no_control");
        builder.Property(r => r.Calificacion).HasColumnName("calificacion");
        builder.Property(r => r.Comentario).HasColumnName("comentario");
        builder.Property(r => r.FechaHora).HasColumnName("fecha_hora")
            .HasConversion(value => value.UtcDateTime, value => new DateTimeOffset(DateTime.SpecifyKind(value, DateTimeKind.Utc)));
        builder.HasOne<Empleado>().WithMany().HasForeignKey(r => r.EmpleadoId);
    }
}
