using System.ComponentModel.DataAnnotations;

namespace espaco_seguro_api._3___Domain;

public enum StatusCertificacao
{
    [Display(Name = "Pendente de análise")]
    Pendente = 1,

    [Display(Name = "Aprovado")]
    Aprovado = 2,

    [Display(Name = "Rejeitado")]
    Rejeitado = 3
}