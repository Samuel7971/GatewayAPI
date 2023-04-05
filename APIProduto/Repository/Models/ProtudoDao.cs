using APIProduto.Core.Domain.Produto;
using APIProduto.Core.Interface.Produto;
using System;

namespace APIProduto.Repository.Models
{
    public class ProtudoDao : IProduto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }

        public ProtudoDao() { }

        public ProtudoDao(IProduto produto)
        {
            Id = produto.Id;
            Nome = produto.Nome;
            Descricao = produto.Descricao;
            Preco = produto.Preco;
            Ativo = produto.Ativo;
            DataCriacao = produto.DataCriacao;
        }

        public IProduto Export() => new Produto(Id, Nome, Descricao, Preco, Ativo, DataCriacao);
    }
}
