using System.ComponentModel;
//Michel Furtado da Silva
namespace ProjetoFinalBiblioteca
{
    public enum EnumGenericoTipo
    {
        [Description("Jornais")]
        Jornais = 1,
        [Description("Calendários e Agendas")]
        CalendariosAgendas = 2,
        [Description("Mapas e Atlas")]
        MapasAtlas = 3,
        [Description("Postais e Cartões de Saudação")]
        PostaisCartoesSaudacao = 4,
        [Description("Papéis de Presente e Material de Embalagem")]
        PapeisPresenteMaterialEmbalagem = 5,
        [Description("DVDs e Blu-rays")]
        DVDsBlurays = 6,
        [Description("CDs e Vinis")]
        CDsVinis = 7,
        [Description("K7")]
        K7 = 8,
        [Description("Jogos de Tabuleiro e Quebra-Cabeças")]
        JogosTabuleiroQuebraCabecas = 9,
        [Description("Material de Papelaria e Escritório")]
        MaterialPapelariaEscritorio = 10,
        [Description("Produtos Relacionados à Cultura Pop")]
        ProdutosRelacionadosCulturaPop = 11,
        [Description("Audiolivros")]
        Audiolivros = 12,
        [Description("Outros")]
        Outros = 13
    }
}