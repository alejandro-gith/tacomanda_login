using Tacomanda.Application.CrearComanda;

namespace Tacomanda.Api.Contracts;

public sealed record CrearComandaRequest(Guid MesaId, IReadOnlyList<DetalleComandaInput> Detalles);
