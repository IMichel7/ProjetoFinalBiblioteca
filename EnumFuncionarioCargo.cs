using System.ComponentModel;
//Michel Furtado da Silva
namespace ProjetoFinalBiblioteca
{
    public enum EnumFuncionarioCargo
    {
        [Description("Gerente")]
        Gerente = 1,
        [Description("Atendente")]
        Atendente = 2,
        [Description("Caixa")]
        Caixa = 3,
        [Description("Estagiário")]
        Estagiario = 4
    }
}