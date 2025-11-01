using System.ComponentModel.DataAnnotations;

namespace espaco_seguro_api._3___Domain;

public enum StatusVerificacaoCard
{
    [Display(Name = "Precisa de revisão")]
    PrecisaRevisao = 1,

    [Display(Name = "Aprovado")]
    Aprovado = 2,

    [Display(Name = "Rejeitado")]
    Rejeitado = 3
}