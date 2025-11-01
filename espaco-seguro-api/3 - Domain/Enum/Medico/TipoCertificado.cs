using System.ComponentModel.DataAnnotations;

namespace espaco_seguro_api._3___Domain;

public enum TipoCertificado
{
    [Display(Name = "CRM - Conselho Regional de Medicina")]
    Crm = 1,

    [Display(Name = "RQE - Registro de Qualificação de Especialista")]
    Rqe = 2,

    [Display(Name = "Diploma de graduação")]
    Diploma = 3,

    [Display(Name = "Título de especialista")]
    TituloEspecialista = 4,

    [Display(Name = "Curso complementar")]
    Curso = 5,

    [Display(Name = "Bootcamp ou certificação livre")]
    Bootcamp = 6
}