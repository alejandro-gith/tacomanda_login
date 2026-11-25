using Tacomanda.Api.Contracts;
using Tacomanda.Application.CrearComanda;

namespace Tacomanda.Api.Mapping;

public interface ICrearComandaCommandFactory
{
    CrearComandaCommand Crear(CrearComandaRequest request);
}
