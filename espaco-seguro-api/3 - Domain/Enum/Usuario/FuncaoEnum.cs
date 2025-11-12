using System.ComponentModel.DataAnnotations;

namespace espaco_seguro_api._3___Domain;

public enum FuncaoEnum
{
    Usuario = 1,
    Medico = 2,
    Curador = 3, //Profissional da saúde certificado
    Administrador = 4
}