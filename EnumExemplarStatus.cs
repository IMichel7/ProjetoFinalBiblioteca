using System.ComponentModel;
//Michel Furtado da Silva
namespace ProjetoFinalBiblioteca
{
    public enum EnumExemplarStatus
    {
        [Description("Pendente")]
        Pendente = 1,
        [Description("Lido")]
        Lido = 2,
        [Description("Emprestado")]
        Emprestado = 3,
        [Description("Devolvido")]
        Devolvido = 4,
        [Description("Perdido")]
        Perdido = 5
    }
}