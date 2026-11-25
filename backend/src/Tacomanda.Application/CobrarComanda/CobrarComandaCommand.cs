using MediatR;
using Tacomanda.Application.Respuestas;

namespace Tacomanda.Application.CobrarComanda;

public sealed record CobrarComandaCommand(int Id, string FormaPago, decimal Monto,
    decimal PorcentajePropina) : IRequest<ComandaDto>;
