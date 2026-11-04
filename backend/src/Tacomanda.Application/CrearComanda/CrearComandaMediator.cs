using Tacomanda.Application.Respuestas;
namespace Tacomanda.Application.CrearComanda;

public sealed class CrearComandaMediator : ICrearComandaMediator
{
    private readonly ICrearComandaValidator _validator;
    private readonly ICrearComandaHandler _handler;

    public CrearComandaMediator(
        ICrearComandaValidator validator,
        ICrearComandaHandler handler)
    {
        _validator = validator;
        _handler = handler;
    }

    public async Task<ComandaDto> EnviarAsync(
        CrearComandaCommand solicitud,
        CancellationToken cancellationToken)
    {
        _validator.Validar(solicitud);

        return await _handler.Handle(solicitud, cancellationToken);
    }
}
