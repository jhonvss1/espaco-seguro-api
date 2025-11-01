using System.ComponentModel.DataAnnotations;

namespace espaco_seguro_api._3___Domain.Chat;

public enum TipoChat
{
    [Display(Name = "Suporte")] Suporte = 1,
    [Display(Name = "Profissional (médico)")] Profissional = 2,
    [Display(Name = "Pessoal (entre usuários)")] Pessoal = 3
}