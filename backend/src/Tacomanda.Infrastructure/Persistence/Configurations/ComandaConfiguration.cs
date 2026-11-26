using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tacomanda.Domain.Comandas;
using Tacomanda.Domain.Empleados;
using Tacomanda.Domain.Mesas;

namespace Tacomanda.Infrastructure.Persistence.Configurations;

public sealed class ComandaConfiguration : IEntityTypeConfiguration<Comanda>
{
    public void Configure(EntityTypeBuilder<Comanda> builder)
    {
        builder.ToTable("comandas");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("id_comanda").ValueGeneratedOnAdd();
        builder.Property(c => c.FechaOperativa)
            .HasColumnName("fecha_operativa")
            .HasColumnType("date")
            .HasConversion(
                fecha => fecha.ToDateTime(TimeOnly.MinValue),
                fecha => DateOnly.FromDateTime(fecha));
        builder.Property(c => c.NumeroDiario).HasColumnName("numero_diario");
        builder.HasIndex(c => new { c.FechaOperativa, c.NumeroDiario }).IsUnique();
        builder.Property(c => c.MesaId).HasColumnName("mesa_id");
        builder.Property(c => c.MeseroId).HasColumnName("no_control");
        builder.Property(c => c.FechaCreacion).HasColumnName("fecha")
            .HasConversion(value => value.UtcDateTime, value => new DateTimeOffset(DateTime.SpecifyKind(value, DateTimeKind.Utc)));
        builder.Property(c => c.FechaCobro).HasColumnName("fecha_cobro")
            .HasConversion(value => value.HasValue ? value.Value.UtcDateTime : (DateTime?)null,
                value => value.HasValue ? new DateTimeOffset(DateTime.SpecifyKind(value.Value, DateTimeKind.Utc)) : (DateTimeOffset?)null);
        builder.Property(c => c.Estado).HasColumnName("estado").HasMaxLength(16)
            .HasConversion(
                value => value == OrderStatus.Pendiente ? "abierta" :
                    value == OrderStatus.EnPreparacion ? "en_preparacion" :
                    value == OrderStatus.Lista ? "lista" :
                    value == OrderStatus.Cobrada ? "cerrada" : "cancelada",
                value => value == "abierta" ? OrderStatus.Pendiente :
                    value == "en_preparacion" ? OrderStatus.EnPreparacion :
                    value == "lista" ? OrderStatus.Lista :
                    value == "cerrada" ? OrderStatus.Cobrada : OrderStatus.Cancelada);
        builder.Property(c => c.FormaPago).HasColumnName("forma_pago").HasMaxLength(20);
        builder.Property(c => c.MontoPagado).HasColumnName("monto_pagado").HasPrecision(8, 2);
        builder.Property(c => c.PorcentajePropina).HasColumnName("porcentaje_propina").HasPrecision(5, 2);
        builder.Property(c => c.Propina).HasColumnName("propina").HasPrecision(8, 2);
        builder.Property(c => c.Version).HasColumnName("version").IsConcurrencyToken();
        builder.Ignore(c => c.Total);
        builder.Ignore(c => c.TotalConPropina);
        builder.HasOne<Mesa>().WithMany().HasForeignKey(c => c.MesaId);
        builder.HasOne<Empleado>().WithMany().HasForeignKey(c => c.MeseroId);
        builder.HasMany(c => c.Detalles).WithOne().HasForeignKey("ComandaId").IsRequired();
        builder.Navigation(c => c.Detalles).HasField("_detalles").UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}