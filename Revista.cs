namespace ProjetoFinalBiblioteca
{//Michel Furtado da Silva
    public class Revista : Exemplar
    {
        public int Edicao { get; set; }
        public int Paginas { get; set; }

        public Revista(
            int ano,
            string genero,
            EnumExemplarStatus status,
            int edicao,
            int paginas)
            : base(ano, genero, status)
        {
            Edicao = edicao;
            Paginas = paginas;
        }

        public override string GetInfo()
        {
            return $"Revista → Ano: {Ano}, Gênero: {Genero}, Status: {Status.GetDescription()}, Edição: {Edicao}, Páginas: {Paginas}";
        }
    }
}