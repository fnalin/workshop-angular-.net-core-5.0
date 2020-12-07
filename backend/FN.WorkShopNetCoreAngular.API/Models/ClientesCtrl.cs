using System;
using System.ComponentModel.DataAnnotations;
using FN.WorkShopNetCoreAngular.Domain.Entities;

namespace FN.WorkShopNetCoreAngular.API.Models.Clientes
{

    public class GetAll
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public int Idade { get; set; }
        public string SexoDescription { get; set; }
    }

    public class GetById
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public int SexoId { get; set; }
        public string SexoDescription { get; set; }
    }

    public class Add
    {
        [Required(ErrorMessage = "O {0} é obrigatório")]
        [StringLength(80, ErrorMessage = "Atingido o limite de {1} caracteres em {0}")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O {0} é obrigatório")]
        [StringLength(80, ErrorMessage = "Atingido o limite de {1} caracteres em {0}")]
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public int Sexo { get; set; }
    }

    public class Update
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [StringLength(80, ErrorMessage = "Atingido o limite de {1} caracteres em {0}")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O {0} é obrigatório")]
        [StringLength(80, ErrorMessage = "Atingido o limite de {1} caracteres em {0}")]
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public int Sexo { get; set; }
    }

    public static class  ModelExtensions 
    {
        public static GetAll ToGetAllModel(this Cliente data)
        {
            return new GetAll {
                Id = data.Id,
                NomeCompleto = $"{data.Nome} {data.Sobrenome}",
                Idade = data.Idade,
                SexoDescription = Enum.GetName(typeof(Domain.Enums.Sexo), data.Sexo),
            };
        }

        public static GetById ToGetByIdModel(this Cliente data)
        {
            return new GetById {
                Id = data.Id,
                Nome = data.Nome,
                Sobrenome = data.Sobrenome,
                Idade = data.Idade,
                SexoId = (int)data.Sexo,
                SexoDescription = Enum.GetName(typeof(Domain.Enums.Sexo), data.Sexo),
            };
        }

        public static Cliente ToEntity(this Add modelAdd)
        {
            return new Cliente(modelAdd.Nome, modelAdd.Sobrenome, modelAdd.Idade, modelAdd.Sexo);
        }

    }
}