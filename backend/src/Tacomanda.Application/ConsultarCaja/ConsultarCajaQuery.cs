using MediatR;

namespace Tacomanda.Application.ConsultarCaja;

public sealed record ConsultarCajaQuery() : IRequest<ResumenCajaDto>;
