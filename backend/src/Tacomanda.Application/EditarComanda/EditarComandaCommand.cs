using MediatR;
using Tacomanda.Application.CrearComanda;
using Tacomanda.Application.Respuestas;

namespace Tacomanda.Application.EditarComanda;

public sealed record EditarComandaCommand(int Id, IReadOnlyList<DetalleComandaInput> Detalles) : IRequest<ComandaDto>;
