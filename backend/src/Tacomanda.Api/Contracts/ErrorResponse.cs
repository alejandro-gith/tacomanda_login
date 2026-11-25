namespace Tacomanda.Api.Contracts;

public sealed record ErrorResponse(int Status, string Message, string TraceId);
