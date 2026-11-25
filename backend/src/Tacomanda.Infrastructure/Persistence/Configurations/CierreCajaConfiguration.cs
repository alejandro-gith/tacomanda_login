using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tacomanda.Domain.Cierres;
using Tacomanda.Domain.Empleados;

namespace Tacomanda.Infrastructure.Persistence.Configurations;

public sealed class CierreCajaConfiguration : IEntityTypeConfiguration<CierreCaja>
{
    public void Configure(EntityTypeBuilder<CierreCaja> builder)
    {
        builder.ToTable("encuestas_cierre");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("id_encuesta").ValueGeneratedOnAdd();
        builder.Property(c => c.EmpleadoId).HasColumnName("no_control");
        builder.Property(c => c.FechaHora).HasColumnName("fecha_hora")
            .HasConversion(value => value.UtcDateTime, value => new DateTimeOffset(DateTime.SpecifyKind(value, DateTimeKind.Utc)));
        builder.Property(c => c.TotalSistema).HasColumnName("total_sistema").HasPrecision(10, 2);
        builder.Property(c => c.TotalContado).HasColumnName("total_contado").HasPrecision(10, 2);
        builder.Property(c => c.Diferencia).HasColumnName("diferencia").HasPrecision(10, 2);
        builder.Property(c => c.HuboIncidencias).HasColumnName("hubo_incidencias");
        builder.Property(c => c.Comentarios).HasColumnName("comentarios");
        builder.HasOne<Empleado>().WithMany().HasForeignKey(c => c.EmpleadoId);
    }
}
