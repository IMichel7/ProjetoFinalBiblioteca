namespace ProjetoFinalBiblioteca
{//Michel Furtado da Silva
    public abstract class Exemplar : IImprimivel
    {
        public int Ano { get; set; }
        public string Genero { get; set; }
        public EnumExemplarStatus Status { get; set; }

        protected Exemplar(int ano, string genero, EnumExemplarStatus status)
        {
            Ano = ano;
            Genero = genero;
            Status = status;
        }

        public abstract string GetInfo();
    }
}