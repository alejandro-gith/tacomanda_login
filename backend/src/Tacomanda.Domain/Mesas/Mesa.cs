using Tacomanda.Domain.Excepciones;

namespace Tacomanda.Domain.Mesas;

public sealed class Mesa
{
    private Mesa() { }

    public Mesa(Guid id, string nombre)
    {
        if (id == Guid.Empty || string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("Mesa inválida.");
        }

        Id = id;
        Nombre = nombre;
        Disponible = true;
    }

    public Guid Id { get; private set; }
    public string Nombre { get; private set; } = "";
    public bool Disponible { get; private set; }
    public int Version { get; private set; }

    public void Ocupar()
    {
        if (!Disponible)
        {
            throw new ReglaDeNegocioException("La mesa ya está ocupada.");
        }

        Disponible = false;
        Version++;
    }
}
