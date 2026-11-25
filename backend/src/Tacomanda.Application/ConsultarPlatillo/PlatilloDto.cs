namespace Tacomanda.Application.ConsultarPlatillo;

public sealed record PlatilloDto(
    int Id, string Nombre, string Categoria, string Descripcion, decimal Precio, string Emoji);
