namespace espaco_seguro_api._3___Domain.Helper;

public class CpfHelper
{
    public string FormatarCpf(string cpf)
    {
        var cpfFormatado = cpf.Replace(".", "").Replace( "-", "");
        return  cpfFormatado;
    }
}