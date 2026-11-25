using Tacomanda.Domain.Excepciones;

namespace Tacomanda.Domain.Mesas;

public sealed class Mesa
{
    private Mesa() { }

    public Mesa(int id, int numero)
    {
        if (id < 0 || numero <= 0)
        {
            throw new ArgumentException("Mesa inválida.");
        }

        Id = id;
        Numero = numero;
        Estado = "libre";
    }

    public int Id { get; private set; }
    public int Numero { get; private set; }
    public string Nombre => $"Mesa {Numero}";
    public string Estado { get; private set; } = "libre";
    public bool Disponible => Estado == "libre";
    public int Version { get; private set; }

    public void Ocupar()
    {
        if (!Disponible)
        {
            throw new ReglaDeNegocioException("La mesa ya está ocupada.");
        }

        Estado = "ocupada";
        Version++;
    }

    public void Liberar()
    {
        if (Disponible)
        {
            throw new ReglaDeNegocioException("La mesa ya está libre.");
        }
        Estado = "libre";
        Version++;
    }
}
