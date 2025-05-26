namespace ProjetoFinalBiblioteca
{//Michel Furtado da Silva
    public class Generico : Exemplar
    {
        public EnumGenericoTipo Tipo { get; set; }

        public Generico(
            int ano,
            string genero,
            EnumExemplarStatus status,
            EnumGenericoTipo tipo)
            : base(ano, genero, status)
        {
            Tipo = tipo;
        }

        public override string GetInfo()
        {
            return $"Genérico → Ano: {Ano}, Gênero: {Genero}, Status: {Status.GetDescription()}, Tipo: {Tipo.GetDescription()}";
        }
    }
}