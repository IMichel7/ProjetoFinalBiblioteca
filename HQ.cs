namespace ProjetoFinalBiblioteca
{//Michel Furtado da Silva
    public class HQ : Exemplar
    {
        public int Edicao { get; set; }

        public HQ(int ano, string genero, EnumExemplarStatus status, int edicao)
            : base(ano, genero, status)
        {
            Edicao = edicao;
        }

        public override string GetInfo()
        {
            return $"HQ → Ano: {Ano}, Gênero: {Genero}, Status: {Status.GetDescription()}, Edição: {Edicao}";
        }
    }
}