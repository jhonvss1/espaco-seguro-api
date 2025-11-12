using System.ComponentModel.DataAnnotations;

namespace espaco_seguro_api._3___Domain;

public enum StatusUsuario
{
    Pendente = 1,
    Ativo = 2,
    Inativo = 3,
    Bloqueado = 4
}