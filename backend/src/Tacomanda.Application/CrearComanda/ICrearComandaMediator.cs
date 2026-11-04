using Tacomanda.Application.Respuestas;
namespace Tacomanda.Application.CrearComanda;

public interface ICrearComandaMediator
{
    Task<ComandaDto> EnviarAsync(CrearComandaCommand solicitud, CancellationToken cancellationToken);
}
