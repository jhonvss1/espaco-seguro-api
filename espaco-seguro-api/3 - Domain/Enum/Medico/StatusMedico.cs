using System.ComponentModel.DataAnnotations;

namespace espaco_seguro_api._3___Domain;

public enum StatusMedico
{
    [Display(Name = "Pendente de verificação")]
    Pendente = 1,

    [Display(Name = "Verificado")]
    Verificado = 2,

    [Display(Name = "Rejeitado")]
    Rejeitado = 3
}