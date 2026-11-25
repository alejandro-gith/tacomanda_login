namespace Tacomanda.Domain.Excepciones;

public sealed class ReglaDeNegocioException : Exception
{
    public ReglaDeNegocioException(string mensaje) : base(mensaje) { }
}
