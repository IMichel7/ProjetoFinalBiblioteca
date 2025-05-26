namespace ProjetoFinalBiblioteca
{//Michel Furtado da Silva
    public class Ebook : Exemplar
    {
        public string Formato { get; set; }
        public int Tamanho { get; set; } // em MB

        public Ebook(
            int ano,
            string genero,
            EnumExemplarStatus status,
            string formato,
            int tamanho)
            : base(ano, genero, status)
        {
            Formato = formato;
            Tamanho = tamanho;
        }

        public override string GetInfo()
        {
            return $"Ebook → Ano: {Ano}, Gênero: {Genero}, Status: {Status.GetDescription()}, Formato: {Formato}, Tamanho: {Tamanho}MB";
        }
    }
}