using APIProduto.Core.Interface.Produto;
using System.Threading.Tasks;

namespace APIProduto.Repository.Interface
{
    public interface IProdutoRepository
    {
        Task<IProduto> BuscarPorIdAsync(int Id);
        Task<int> InserirAsync(IProduto produto);
        Task<int> AtualizaAsync(IProduto produto);
        Task<int> AtualizarStatus(int id, bool status);
    }
}
