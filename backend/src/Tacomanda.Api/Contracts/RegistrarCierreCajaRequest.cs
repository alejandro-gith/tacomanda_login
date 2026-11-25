namespace Tacomanda.Api.Contracts;

public sealed record RegistrarCierreCajaRequest(decimal TotalContado, bool HuboIncidencias, string Comentarios);
