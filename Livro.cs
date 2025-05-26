namespace ProjetoFinalBiblioteca
{//Michel Furtado da Silva
    public class Livro : Exemplar
    {
        public int Paginas { get; set; }
        public string TipoCapa { get; set; }

        public Livro(
            int ano,
            string genero,
            EnumExemplarStatus status,
            int paginas,
            string tipoCapa)
            : base(ano, genero, status)
        {
            Paginas = paginas;
            TipoCapa = tipoCapa;
        }

        public override string GetInfo()
        {
            return $"Livro → Ano: {Ano}, Gênero: {Genero}, Status: {Status.GetDescription()}, Páginas: {Paginas}, Capa: {TipoCapa}";
        }
    }
}