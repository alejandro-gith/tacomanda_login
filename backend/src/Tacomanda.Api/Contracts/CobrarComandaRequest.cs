namespace Tacomanda.Api.Contracts;

public sealed record CobrarComandaRequest(string FormaPago, decimal Monto, decimal PorcentajePropina);
