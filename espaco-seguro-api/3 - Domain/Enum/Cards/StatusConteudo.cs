using System.ComponentModel.DataAnnotations;

namespace espaco_seguro_api._3___Domain;

public enum StatusConteudo
{
    Rascunho   = 1, // criado pelo curador (rascunho local)
    Pendente   = 2, // enviado para revisão (aguardando revisor)
    Revisao    = 3, // em revisão por médico/adm
    Publicado  = 4,
    Arquivado  = 5
}