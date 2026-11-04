namespace Tacomanda.Application.ConsultarPlatillo;

public sealed record PlatilloDto(
    Guid Id, string Nombre, string Categoria, string Descripcion, decimal Precio, string Emoji);
