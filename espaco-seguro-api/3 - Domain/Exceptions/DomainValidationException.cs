namespace espaco_seguro_api._3___Domain.Exceptions;

public class DomainValidationException : Exception
{
    public DomainValidationException(string mensagem) : base(mensagem) { }   
}