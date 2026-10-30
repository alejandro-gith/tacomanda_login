namespace Tacomanda.Application;

internal static class ValidationRules
{
    public static void Require(bool condition, string developerMessage)
    {
        if (!condition)
        {
            throw new RequestValidationException(developerMessage);
        }
    }
}
