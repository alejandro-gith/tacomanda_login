namespace Tacomanda.Api.Contracts;

public sealed record PlatilloRequest(string Nombre, string Categoria, string Descripcion, decimal Precio, string Emoji);
