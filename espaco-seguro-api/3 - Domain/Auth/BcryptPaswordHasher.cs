using espaco_seguro_api._3___Domain.Security;

namespace espaco_seguro_api._3___Domain.Auth;

public class BcryptPaswordHasher : IPasswordHasher
{
    public string Hash(string senhaPura) =>
        BCrypt.Net.BCrypt.HashPassword(senhaPura); 
    public bool Verify(string senhaPura, string hash) =>
        !string.IsNullOrWhiteSpace(hash) &&
        (hash.StartsWith("$2a$") || hash.StartsWith("$2b$") || hash.StartsWith("$2y$")) &&
        BCrypt.Net.BCrypt.Verify(senhaPura, hash);      
}