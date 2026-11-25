using Tacomanda.Application.CrearComanda;

namespace Tacomanda.Api.Contracts;

public sealed record CrearComandaRequest(int MesaId, IReadOnlyList<DetalleComandaInput> Detalles);
