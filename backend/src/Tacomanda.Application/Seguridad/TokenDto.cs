namespace Tacomanda.Application.Seguridad;

public sealed record TokenDto(string AccessToken, DateTimeOffset ExpiraEn);
