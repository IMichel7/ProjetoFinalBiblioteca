using System;
//Michel Furtado da Silva
namespace ProjetoFinalBiblioteca
{
    public class Leitor : Pessoa
    {
        public string Tipo { get; set; }

        public Leitor(DateTime nascimento, string cpf, string telefone, string tipo)
            : base(nascimento, cpf, telefone)
        {
            Tipo = tipo;
        }

        public override string GetInfo()
        {
            return $"Leitor → Nasc.: {Nascimento:dd/MM/yyyy}, CPF: {Cpf}, Tel.: {Telefone}, Tipo: {Tipo}";
        }
    }
}