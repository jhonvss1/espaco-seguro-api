using System.ComponentModel.DataAnnotations;

namespace espaco_seguro_api._3___Domain.Chat;

public enum StatusChat
{
    [Display(Name = "Ativo")] Ativo = 1,
    [Display(Name = "Fechado")] Fechado = 2,
    [Display(Name = "Abandonado")] Abandonado = 3,
}