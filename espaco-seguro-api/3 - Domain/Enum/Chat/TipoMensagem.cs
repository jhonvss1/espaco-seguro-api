using System.ComponentModel.DataAnnotations;

namespace espaco_seguro_api._3___Domain.Chat;

public enum TipoMensagem
{
    Texto = 1,
    Audio = 2,
    Imagem = 3,
    Video = 4,
    Sistema = 5
}