using APIProduto.Core.Interface.Produto;
using APIProduto.Repository.Interface;
using APIProduto.Repository.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace APIProduto.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataBaseSettings _dataBaseSettings;

        public ProdutoRepository(IOptions<DataBaseSettings> options)
        {
            _dataBaseSettings = options.Value;
        }
        public async Task<IProduto> BuscarPorIdAsync(int id)
        {
            using (var conn = new SqlConnection(_dataBaseSettings.ConnectionStringEstudo))
            {
                var sql = $"SELECT Id, Nome, Descricao, Preco, Ativo FROM Estudo..Produto WHERE Id = @id";
                var result = await conn.QuerySingleOrDefaultAsync<ProtudoDao>(sql, new { id });
                return result?.Export();
            }
        }

        public async Task<int> AtualizaAsync(IProduto produto)
        {
            using(var conn = new SqlConnection(_dataBaseSettings.ConnectionStringEstudo))
            {
                var query = $@"UPDATE Estudo..Produto 
                               SET Nome = @nome
                               , Descricao = @descricao
                               , Preco = @preco
                               , Ativo = @ativo 
                                 WHERE Id = @id";
                var affected = await conn.ExecuteAsync(query, produto);
                return affected;
            }
        }

        public async Task<int> AtualizarStatus(int id, bool status)
        {
            using(var conn = new SqlConnection(_dataBaseSettings.ConnectionStringEstudo))
            {
                var query = $@"UPDATE Estudo..Produto SET Ativo = @status WHERE Id = @id";
                var affectedRows = await conn.ExecuteAsync(query, new { id, status });
                return affectedRows;
            }
        }
    }
}
