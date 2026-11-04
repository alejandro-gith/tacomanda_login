using Tacomanda.Application.Respuestas;
using Tacomanda.Domain.Comandas;
using Tacomanda.Domain.Empleados;
using Tacomanda.Domain.Excepciones;
using Tacomanda.Domain.Interfaces;
using Tacomanda.Domain.Mesas;
using Tacomanda.Domain.Platillos;

namespace Tacomanda.Application.CrearComanda;

public sealed class CrearComandaHandler : ICrearComandaHandler
{
    private readonly IMesaRepository _mesas;
    private readonly IPlatilloRepository _platillos;
    private readonly IComandaRepository _comandas;
    private readonly IMeseroReader _meseros;
    private readonly IUnidadDeTrabajo _unidadDeTrabajo;
    private readonly IComandaDtoMapper _mapper;

    public CrearComandaHandler(
        IMesaRepository mesas,
        IPlatilloRepository platillos,
        IComandaRepository comandas,
        IMeseroReader meseros,
        IUnidadDeTrabajo unidadDeTrabajo,
        IComandaDtoMapper mapper)
    {
        _mesas = mesas;
        _platillos = platillos;
        _comandas = comandas;
        _meseros = meseros;
        _unidadDeTrabajo = unidadDeTrabajo;
        _mapper = mapper;
    }

    public async Task<ComandaDto> Handle(
        CrearComandaCommand command,
        CancellationToken cancellationToken)
    {
        Mesa? mesa = await _mesas.ObtenerAsync(command.MesaId, cancellationToken);
        if (mesa is null)
        {
            throw new KeyNotFoundException("La mesa no existe.");
        }

        Empleado? mesero = await _meseros.BuscarPorIdAsync(command.MeseroId, cancellationToken);
        if (mesero is null || !mesero.Activo || mesero.Rol != EmployeeRole.Mesero)
        {
            throw new UnauthorizedAccessException("El mesero no está habilitado.");
        }

        List<DetalleComanda> detalles = new();
        foreach (DetalleComandaInput input in command.Detalles)
        {
            Platillo? platillo = await _platillos.ObtenerAsync(input.PlatilloId, cancellationToken);
            if (platillo is null || !platillo.Activo)
            {
                throw new ReglaDeNegocioException("El platillo no está disponible.");
            }

            detalles.Add(new DetalleComanda(
                platillo.Id, platillo.Nombre, platillo.Precio,
                input.Cantidad, input.Observaciones));
        }

        Comanda comanda = new(mesa, mesero.Id, detalles);
        mesa.Ocupar();
        _comandas.Agregar(comanda);
        await _unidadDeTrabajo.ConfirmarAsync(cancellationToken);

        return _mapper.Convertir(comanda);
    }
}
