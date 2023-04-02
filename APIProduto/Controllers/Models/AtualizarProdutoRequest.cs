using APIProduto.Core.Domain.Produto;
using APIProduto.Core.Interface.Produto;
using System.Text.Json.Serialization;

namespace APIProduto.Controllers.Models
{
    public class AtualizarProdutoRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }

        public IProduto ToProduto() => new Produto(Id, Nome, Descricao, Preco, Ativo);
    }
}
