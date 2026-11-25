using System.Security.Cryptography;

namespace Tacomanda.Infrastructure.Seguridad;

public sealed class JwtSettings
{
    private readonly byte[] _signingKey;

    public JwtSettings(string issuer, string audience, string? secret)
    {
        Issuer = issuer;
        Audience = audience;
        _signingKey = secret is null ? RandomNumberGenerator.GetBytes(32) :
            System.Text.Encoding.UTF8.GetBytes(secret);
        if (_signingKey.Length < 32)
            throw new ArgumentException("La clave JWT debe tener al menos 32 bytes.", nameof(secret));
    }

    public string Issuer { get; }
    public string Audience { get; }
    public byte[] SigningKey
    {
        get { return (byte[])_signingKey.Clone(); }
    }
}
