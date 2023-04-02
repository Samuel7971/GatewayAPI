using APIProduto.Core.Interface.Produto;
using System.Globalization;

namespace APIProduto.Services.Models
{
    public class ProdutoModel : IProduto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }
        public bool Ativo { get; set; }

        public ProdutoModel() { }

        public ProdutoModel(IProduto protudo)
        {
            Id = protudo.Id;
            Nome = protudo.Nome;
            Descricao = protudo.Descricao;
            Preco = protudo.Preco;
            Ativo = protudo.Ativo;
        }

        public static implicit operator string(ProdutoModel produto)
            => $"{produto.Id} ; {produto.Nome} ; {produto.Descricao} ; {produto.Preco} ; {produto.Ativo}";

        public static implicit operator ProdutoModel(string line)
        {
            var data = line.Split(";");
            return new ProdutoModel
            {
                Id = int.Parse(data[0]),
                Nome = data[1],
                Descricao = data[2],
                Preco = decimal.Parse(data[3], NumberStyles.Number),
                Ativo = bool.Parse(data[4])
            };
        }
    }
}
