namespace FN.WorkShopNetCoreAngular.Domain.Entities
{
    public class Cliente : Entity
    {

        public Cliente(int id, string nome, string sobrenome, int idade, Enums.Sexo sexo)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Idade = idade;
            this.Sexo = sexo;
        }

        public Cliente(string nome, string sobrenome, int idade, Enums.Sexo sexo)
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Idade = idade;
            this.Sexo = sexo;
        }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string NomeCompleto => $"{Nome} {Sobrenome}";
        public int Idade { get; private set; }

        public Enums.Sexo Sexo { get; private set; }

    }
}