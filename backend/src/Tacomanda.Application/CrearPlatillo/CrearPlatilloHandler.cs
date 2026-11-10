using AutoMapper;
using MediatR;
using Tacomanda.Application.ConsultarPlatillo;
using Tacomanda.Domain.Interfaces;
using Tacomanda.Domain.Platillos;

namespace Tacomanda.Application.CrearPlatillo;

public sealed class CrearPlatilloHandler : IRequestHandler<CrearPlatilloCommand, PlatilloDto>
{
    private readonly IPlatillosEscrituraRepository _platillos;
    private readonly IUnidadDeTrabajo _unidadDeTrabajo;
    private readonly IMapper _mapper;

    public CrearPlatilloHandler(IPlatillosEscrituraRepository platillos, IUnidadDeTrabajo unidadDeTrabajo, IMapper mapper)
    {
        _platillos = platillos;
        _unidadDeTrabajo = unidadDeTrabajo;
        _mapper = mapper;
    }

    public async Task<PlatilloDto> Handle(CrearPlatilloCommand command, CancellationToken cancellationToken)
    {
        Platillo platillo = new(Guid.NewGuid(), command.Nombre.Trim(), command.Categoria.Trim(),
            command.Descripcion.Trim(), command.Precio, command.Emoji.Trim());
        _platillos.Agregar(platillo);
        await _unidadDeTrabajo.ConfirmarAsync(cancellationToken);
        return _mapper.Map<PlatilloDto>(platillo);
    }
}
