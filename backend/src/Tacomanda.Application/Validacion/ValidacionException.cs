namespace Tacomanda.Application.Validacion;

public sealed class ValidacionException : Exception
{
    public ValidacionException(string mensaje) : base(mensaje) { }
}
