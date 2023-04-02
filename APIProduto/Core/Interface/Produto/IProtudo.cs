namespace APIProduto.Core.Interface.Produto
{
    public interface IProduto
    {
        int Id { get; }
        string Nome { get; }
        string Descricao { get; }
        decimal Preco { get; }
        bool Ativo { get; }
    }
}
