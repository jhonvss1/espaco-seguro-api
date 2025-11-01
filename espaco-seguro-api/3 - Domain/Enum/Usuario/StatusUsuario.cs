using System.ComponentModel.DataAnnotations;

namespace espaco_seguro_api._3___Domain;

public enum StatusUsuario
{
    [Display(Name = "Pendente de verificação")] Pendente = 1,
    [Display(Name = "Ativo")] Ativo = 2,
    [Display(Name = "Inativo")] Inativo = 3,
    [Display(Name = "Bloqueado")] Bloqueado = 4
}