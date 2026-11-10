using MediatR;
using Tacomanda.Domain.Interfaces;
using Tacomanda.Domain.Platillos;

namespace Tacomanda.Application.EliminarPlatillo;

public sealed class EliminarPlatilloHandler : IRequestHandler<EliminarPlatilloCommand, Guid>
{
    private readonly IPlatilloRepository _platillos;
    private readonly IUnidadDeTrabajo _unidadDeTrabajo;

    public EliminarPlatilloHandler(IPlatilloRepository platillos, IUnidadDeTrabajo unidadDeTrabajo)
    {
        _platillos = platillos;
        _unidadDeTrabajo = unidadDeTrabajo;
    }

    public async Task<Guid> Handle(EliminarPlatilloCommand command, CancellationToken cancellationToken)
    {
        Platillo platillo = await _platillos.ObtenerAsync(command.Id, cancellationToken)
            ?? throw new KeyNotFoundException("El platillo no existe.");
        platillo.Desactivar();
        await _unidadDeTrabajo.ConfirmarAsync(cancellationToken);
        return platillo.Id;
    }
}
