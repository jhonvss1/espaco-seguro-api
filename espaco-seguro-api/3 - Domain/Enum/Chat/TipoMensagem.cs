using System.ComponentModel.DataAnnotations;

namespace espaco_seguro_api._3___Domain.Chat;

public enum TipoMensagem
{
    [Display(Name = "Texto")] Texto = 1,
    [Display(Name = "Áudio")] Audio = 2,
    [Display(Name = "Imagem")] Imagem = 3,
    [Display(Name = "Vídeo")] Video = 4,
    [Display(Name = "Sistema (automática)")] Sistema = 5
}