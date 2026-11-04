using Tacomanda.Domain.Comandas;

namespace Tacomanda.Application.Respuestas;

public interface IComandaDtoMapper
{
    ComandaDto Convertir(Comanda comanda);
}
