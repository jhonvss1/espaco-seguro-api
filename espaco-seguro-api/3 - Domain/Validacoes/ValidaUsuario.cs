using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Helper;

namespace espaco_seguro_api._3___Domain.Validacoes;

public class ValidaUsuario
{
    public bool ValidarUsuario(Usuario usuario)
    {
        
        if(string.IsNullOrEmpty(usuario.Nome) || string.IsNullOrEmpty(usuario.Email))
        {
            return false;
        }

        var cpfHelper = new CpfHelper();
        var cpfFormatado = cpfHelper.FormatarCpf(usuario.Cpf);
        if (usuario.Cpf == null || cpfFormatado.Length != 11)
        {
            return false;
        }

        var idadeDoUsuario = DateTime.Today.Year - usuario.DataNascimento.Value.Year;
        if (usuario.DataNascimento == null || idadeDoUsuario < 18)
        {
            return false;
        }
        
        if(usuario.Telefone == null)
        {
            return false;
        }

        if (!usuario.AceitouTermos)
        {
            return false;
        }
        
        return true;
    }
}