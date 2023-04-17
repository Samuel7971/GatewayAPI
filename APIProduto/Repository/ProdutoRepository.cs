using APIProduto.Core.Interface.Produto;
using APIProduto.Repository.Interface;
using APIProduto.Repository.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<IProduto>> BuscarTodos()
        {
            var sql = $@"SELECT Id, Nome, Descricao, Preco, Ativo, DataCriacao FROM Estudo..Produto";
            using (var conn = new SqlConnection(_dataBaseSettings.ConnectionStringEstudo))
            {
                var result = await conn.QueryAsync<ProtudoDao>(sql);
                return result?.AsList();
            }
        }

        public async Task<IProduto> BuscarPorIdAsync(int id)
        {
            using (var conn = new SqlConnection(_dataBaseSettings.ConnectionStringEstudo))
            {
                var sql = $"SELECT Id, Nome, Descricao, Preco, Ativo, DataCriacao FROM Estudo..Produto WHERE Id = @id";
                var result = await conn.QuerySingleOrDefaultAsync<ProtudoDao>(sql, new { id });
                return result?.Export();
            }
        }

        public async Task<int> InserirAsync(IProduto produto)
        {
            using (var conn = new SqlConnection(_dataBaseSettings.ConnectionStringEstudo))
            {
                var query = $@"INSERT INTO Estudo..Produto(Nome, Descricao, Preco, Ativo, DataCriacao)
                               VALUES(@nome, @descricao, @preco, @ativo, @dataCriacao)
                               SELECT @@IDENTITY ";
                return await conn.QueryFirstAsync<int>(query, produto);
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

        public async Task<int> DeletarPorId(int id)
        {
            using (var conn = new SqlConnection(_dataBaseSettings.ConnectionStringEstudo))
            {
                var query = $"DELETE FROM Estudo..Produto WHERE Id = @id";
                var affectedRows = await conn.ExecuteAsync(query, new { id });
                return affectedRows;
            }
        }
    }
}
