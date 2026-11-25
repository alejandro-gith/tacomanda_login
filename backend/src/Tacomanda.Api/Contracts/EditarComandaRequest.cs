using Tacomanda.Application.CrearComanda;

namespace Tacomanda.Api.Contracts;

public sealed record EditarComandaRequest(IReadOnlyList<DetalleComandaInput> Detalles);
