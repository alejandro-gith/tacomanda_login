using MediatR;

namespace Tacomanda.Application.RegistrarCierreCaja;

public sealed record RegistrarCierreCajaCommand(decimal TotalContado, bool HuboIncidencias,
    string Comentarios) : IRequest<CierreCajaDto>;
