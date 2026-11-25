namespace Tacomanda.Application.RegistrarCierreCaja;

public sealed record CierreCajaDto(int Id, DateTimeOffset FechaHora, decimal TotalSistema,
    decimal TotalContado, decimal Diferencia, bool HuboIncidencias, string Comentarios);
