namespace Tacomanda.Application;

public sealed class RequestValidationException(string message)
    : Exception(message);
