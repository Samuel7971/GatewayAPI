using APIProduto.Core.Interface.Produto;
using System;

namespace APIProduto.Core.Domain.Produto
{
    public class Produto : IProduto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get ; set; }

        public Produto(int id, string nome, string descricao, decimal preco, bool ativo, DateTime dateTime)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Ativo = ativo;
            DataCriacao = dateTime;
        }
    }
}
