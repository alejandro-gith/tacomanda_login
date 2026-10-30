namespace Tacomanda.Domain;

public sealed class ConflictException(string message)
    : DomainException(message);
