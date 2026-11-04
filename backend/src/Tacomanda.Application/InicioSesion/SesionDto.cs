namespace Tacomanda.Application.InicioSesion;

public sealed record SesionDto(
    Guid EmpleadoId,
    string Usuario,
    string Nombre,
    string Rol,
    string AccessToken,
    DateTimeOffset ExpiraEn);
