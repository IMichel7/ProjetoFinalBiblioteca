using System;
//Michel Furtado da Silva
namespace ProjetoFinalBiblioteca
{
    public class Funcionario : Pessoa
    {
        public EnumFuncionarioCargo Cargo { get; set; }
        public decimal Salario { get; set; }
        public int CargaHoraria { get; set; }
        public string Funcao { get; set; }

        public Funcionario(
            DateTime nascimento,
            string cpf,
            string telefone,
            EnumFuncionarioCargo cargo,
            decimal salario,
            int cargaHoraria,
            string funcao)
            : base(nascimento, cpf, telefone)
        {
            Cargo = cargo;
            Salario = salario;
            CargaHoraria = cargaHoraria;
            Funcao = funcao;
        }

        public override string GetInfo()
        {
            return $"Funcionário → CPF: {Cpf}, Cargo: {Cargo.GetDescription()}, Salário: {Salario:C}, Carga: {CargaHoraria}h, Função: {Funcao}";
        }
    }
}