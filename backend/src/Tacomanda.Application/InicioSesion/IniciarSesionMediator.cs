namespace Tacomanda.Application.InicioSesion;

public sealed class IniciarSesionMediator : IIniciarSesionMediator
{
    private readonly IIniciarSesionValidator _validator;
    private readonly IIniciarSesionHandler _handler;

    public IniciarSesionMediator(
        IIniciarSesionValidator validator,
        IIniciarSesionHandler handler)
    {
        _validator = validator;
        _handler = handler;
    }

    public async Task<SesionDto> EnviarAsync(
        IniciarSesionCommand solicitud,
        CancellationToken cancellationToken)
    {
        _validator.Validar(solicitud);

        return await _handler.Handle(solicitud, cancellationToken);
    }
}
