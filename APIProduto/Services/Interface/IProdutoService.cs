using APIProduto.Core.Interface.Produto;
using System.Threading.Tasks;

namespace APIProduto.Services.Interface
{
    public interface IProdutoService
    {
        Task<IProduto> BuscarPorIdAsync(int id);
        Task<int> AtualizaAsync(IProduto produto);
        Task<int> AtualizarStatus(int id, bool status);
    }
}
