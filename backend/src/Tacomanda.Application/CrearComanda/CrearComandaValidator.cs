using Tacomanda.Application.Validacion;

namespace Tacomanda.Application.CrearComanda;

public sealed class CrearComandaValidator : IValidator<CrearComandaCommand>
{
    public void Validar(CrearComandaCommand command)
    {
        if (command.MesaId <= 0 || command.MeseroId <= 0)
        {
            throw new ValidacionException("Los identificadores de mesa y mesero son requeridos.");
        }

        if (command.Detalles.Count < 1 || command.Detalles.Count > 100)
        {
            throw new ValidacionException("Se requieren entre 1 y 100 detalles.");
        }

        HashSet<int> platillos = new();
        foreach (DetalleComandaInput detalle in command.Detalles)
        {
            if (detalle is null || detalle.PlatilloId <= 0 ||
                detalle.Cantidad < 1 || detalle.Cantidad > 99 ||
                detalle.Observaciones is null || detalle.Observaciones.Length > 200)
            {
                throw new ValidacionException("Identificador, cantidad u observaciones inválidos.");
            }

            if (!platillos.Add(detalle.PlatilloId))
            {
                throw new ValidacionException("Agrupa cada platillo en un único detalle.");
            }
        }
    }
}
