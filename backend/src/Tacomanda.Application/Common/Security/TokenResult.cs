namespace Tacomanda.Application;

public sealed record TokenResult(string Token, DateTimeOffset ExpiresAt);
