using System.ComponentModel.DataAnnotations;

namespace espaco_seguro_api._3___Domain;

public enum FuncaoEnum
{
    Usuario = 0,
    Medico = 1,
    Curador = 2, //Profissional da saúde certificado
    Administrador = 3
}