using APIProduto.Core.Interface.Produto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIProduto.Services.Interface
{
    public interface IProdutoService
    {
        Task<IEnumerable<IProduto>> BuscarTodos();
        Task<IProduto> BuscarPorIdAsync(int id);
        Task<int> InserirAsync(IProduto produto);
        Task<int> AtualizaAsync(IProduto produto);
        Task<int> AtualizarStatus(int id, bool status);
        Task<int> DeletarPorId(int id);
    }
}
