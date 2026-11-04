using System.Security.Cryptography;
using Tacomanda.Application;

namespace Tacomanda.Infrastructure;

public sealed class Pbkdf2PasswordService : IPasswordService
{
    private const int Iterations = 120_000;

    public string Hash(string password)
    {
        if (password.Length < 8)
        {
            throw new ArgumentException(
                "Password must contain at least eight characters.",
                nameof(password));
        }

        var salt = RandomNumberGenerator.GetBytes(16);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            HashAlgorithmName.SHA256,
            32);

        return $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
    }

    public bool Verify(string stored, string password)
    {
        try
        {
            var parts = stored.Split('.');
            if (parts.Length != 3
                || !int.TryParse(parts[0], out var iterations))
            {
                return false;
            }

            var salt = Convert.FromBase64String(parts[1]);
            var expected = Convert.FromBase64String(parts[2]);
            var actual = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations,
                HashAlgorithmName.SHA256,
                expected.Length);

            return CryptographicOperations.FixedTimeEquals(actual, expected);
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
