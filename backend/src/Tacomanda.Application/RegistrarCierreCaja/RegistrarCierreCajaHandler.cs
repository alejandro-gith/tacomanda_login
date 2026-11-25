using MediatR;
using Tacomanda.Application.Seguridad;
using Tacomanda.Domain.Cierres;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Application.RegistrarCierreCaja;

public sealed class RegistrarCierreCajaHandler : IRequestHandler<RegistrarCierreCajaCommand, CierreCajaDto>
{
    private readonly ICierresLecturaRepository _lectura;
    private readonly ICierreCajaRepository _escritura;
    private readonly IUsuarioActual _usuario;
    private readonly IUnidadDeTrabajo _unidad;

    public RegistrarCierreCajaHandler(ICierresLecturaRepository lectura, ICierreCajaRepository escritura,
        IUsuarioActual usuario, IUnidadDeTrabajo unidad)
    {
        _lectura = lectura;
        _escritura = escritura;
        _usuario = usuario;
        _unidad = unidad;
    }

    public async Task<CierreCajaDto> Handle(RegistrarCierreCajaCommand command, CancellationToken ct)
    {
        decimal total = await _lectura.TotalPendienteAsync(ct);
        CierreCaja cierre = new(_usuario.ObtenerId(), total, command.TotalContado,
            command.HuboIncidencias, command.Comentarios.Trim());
        _escritura.Agregar(cierre);
        await _unidad.ConfirmarAsync(ct);
        return new CierreCajaDto(cierre.Id, cierre.FechaHora, cierre.TotalSistema,
            cierre.TotalContado, cierre.Diferencia, cierre.HuboIncidencias, cierre.Comentarios);
    }
}
