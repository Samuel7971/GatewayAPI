using APIProduto.Core.Domain.Produto;
using APIProduto.Core.Interface.Produto;
using System;
using System.Text.Json.Serialization;

namespace APIProduto.Controllers.Models
{
    public class InserirProdutoRequest 
    {
        [JsonIgnore] public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public IProduto ToProduto() => new Produto(Id, Nome, Descricao, Preco, Ativo, DataCriacao);
    }
}
