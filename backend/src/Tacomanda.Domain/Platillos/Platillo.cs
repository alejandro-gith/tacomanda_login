using Tacomanda.Domain.Excepciones;

namespace Tacomanda.Domain.Platillos;

public sealed class Platillo
{
    private Platillo() { }

    public Platillo(Guid id, string nombre, string categoria, string descripcion, decimal precio, string emoji)
    {
        if (id == Guid.Empty || string.IsNullOrWhiteSpace(nombre) || precio <= 0)
        {
            throw new ArgumentException("Platillo inválido.");
        }

        Id = id;
        Nombre = nombre;
        Categoria = categoria;
        Descripcion = descripcion;
        Precio = precio;
        Emoji = emoji;
        Activo = true;
    }

    public Guid Id { get; private set; }
    public string Nombre { get; private set; } = "";
    public string Categoria { get; private set; } = "";
    public string Descripcion { get; private set; } = "";
    public decimal Precio { get; private set; }
    public string Emoji { get; private set; } = "";
    public bool Activo { get; private set; }

    public void Editar(string nombre, string categoria, string descripcion, decimal precio, string emoji)
    {
        if (!Activo || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(categoria) || precio <= 0)
        {
            throw new ReglaDeNegocioException("No se puede editar el platillo.");
        }

        Nombre = nombre;
        Categoria = categoria;
        Descripcion = descripcion;
        Precio = precio;
        Emoji = emoji;
    }

    public void Desactivar()
    {
        if (!Activo)
        {
            throw new ReglaDeNegocioException("El platillo ya está desactivado.");
        }

        Activo = false;
    }
}
