using System.ComponentModel.DataAnnotations;

namespace espaco_seguro_api._3___Domain;

public enum FuncaoEnum
{
    [Display(Name = "Usuário comum")] Usuario = 1,
    [Display(Name = "Médico")] Medico = 2,
    [Display(Name = "Editor / Curador")] Editor = 3,
    [Display(Name = "Administrador")] Administrador = 4
}