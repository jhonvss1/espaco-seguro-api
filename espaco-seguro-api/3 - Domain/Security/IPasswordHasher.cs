namespace espaco_seguro_api._3___Domain.Security;

public interface IPasswordHasher
{
    string Hash(string senhaPura);
    bool Verify(string senhaPura, string hash);
}