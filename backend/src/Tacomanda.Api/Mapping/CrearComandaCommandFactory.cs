using Tacomanda.Api.Contracts;
using Tacomanda.Application.CrearComanda;
using Tacomanda.Application.Seguridad;

namespace Tacomanda.Api.Mapping;

public sealed class CrearComandaCommandFactory : ICrearComandaCommandFactory
{
    private readonly IUsuarioActual _usuarioActual;

    public CrearComandaCommandFactory(IUsuarioActual usuarioActual)
    {
        _usuarioActual = usuarioActual;
    }

    public CrearComandaCommand Crear(CrearComandaRequest request)
    {
        return new CrearComandaCommand(
            request.MesaId,
            _usuarioActual.ObtenerId(),
            request.Detalles);
    }
}
