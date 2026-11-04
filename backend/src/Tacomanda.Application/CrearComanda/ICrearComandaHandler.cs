using Tacomanda.Application.Respuestas;
namespace Tacomanda.Application.CrearComanda;

public interface ICrearComandaHandler
{
    Task<ComandaDto> Handle(CrearComandaCommand solicitud, CancellationToken cancellationToken);
}
