using System;
using System.Windows.Forms;
//Michel Furtado da Silva
namespace ProjetoFinalBiblioteca
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmMenu());
        }
    }
}
