using System.ComponentModel.DataAnnotations;

namespace espaco_seguro_api._3___Domain;

public enum StatusConteudo
{
    [Display(Name = "Rascunho")] Rascunho = 1,
    [Display(Name = "Em revisão")] Revisado = 2,
    [Display(Name = "Publicado")] Publicado = 3,
    [Display(Name = "Arquivado")] Arquivado = 4
}