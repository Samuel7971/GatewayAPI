using APIProduto.Core.Interface.Produto;
using APIProduto.Repository.Interface;
using APIProduto.Services.Interface;
using System.Threading.Tasks;

namespace APIProduto.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IProduto> BuscarPorIdAsync(int id) => await _produtoRepository.BuscarPorIdAsync(id);

        public async Task<int> InserirAsync(IProduto produto) => await _produtoRepository.InserirAsync(produto);

        public async Task<int> AtualizaAsync(IProduto produto) => await _produtoRepository.AtualizaAsync(produto);

        public async Task<int> AtualizarStatus(int id, bool status) => await _produtoRepository.AtualizarStatus(id, status);

        public async Task<int> DeletarPorId(int id) => await _produtoRepository.DeletarPorId(id);
    }
}
