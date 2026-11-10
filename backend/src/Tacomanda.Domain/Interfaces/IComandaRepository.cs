using Tacomanda.Domain.Comandas;

namespace Tacomanda.Domain.Interfaces;

public interface IComandaRepository
{
    void Agregar(Comanda comanda);
}
