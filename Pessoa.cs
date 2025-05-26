using System;
//Michel Furtado da Silva
namespace ProjetoFinalBiblioteca
{
    public abstract class Pessoa : IImprimivel
    {
        public DateTime Nascimento { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }

        protected Pessoa(DateTime nascimento, string cpf, string telefone)
        {
            Nascimento = nascimento;
            Cpf = cpf;
            Telefone = telefone;
        }

        public abstract string GetInfo();
    }
}