using APIProduto.Attributes;
using APIProduto.Controllers.Models;
using APIProduto.Controllers.Shared;
using APIProduto.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APIProduto.Controllers
{
    [Route("[controller]")]
    public class ProdutoController : ApiController
    {
        /// <summary>
        /// Buscar Por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="produtoService"></param>
        /// <returns>Um produto com base no Id</returns>
        /// <response code="200">Retorno produto</response>
        /// <response code="400">Se o Id não for informado</response>
        /// <response code="404">Se o produto não for encontrado</response>
        [HttpGet("BuscarPorId/{id}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        [CustomResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarPorIdAsync(int id, [FromServices] IProdutoService produtoService)
        {
            if (id <= 0) return ResponseBadRequest();

            var response = await produtoService.BuscarPorIdAsync(id);

            if (response is null) return ResponseNotFound();

            return ResponseOk(response);
        }

        /// <summary>
        /// Inserir novo Produto
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="produtoService"></param>
        /// <returns></returns>
        /// <response code="200">Se o produto for criado</response>
        /// <response code="400">Se o produto não for criado</response>
        [HttpPost("InserirProduto")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InserirAsync([FromBody] InserirProdutoRequest produto, [FromServices] IProdutoService produtoService)
        {
            if (!ModelState.IsValid)
                return ResponseBadRequest();

            var retorno = await produtoService.InserirAsync(produto.ToProduto());
            if(retorno > 0) return ResponseCreated();

            return ResponseBadRequest("Erro ao inserir novo Produto.");
        }

        /// <summary>
        /// Atualizar Produto
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="produtoService"></param>
        /// <returns></returns>
        /// <response code="200">Se o produto for atualizado</response>
        /// <response code="400">Se o produto não for atualizado</response>
        /// <response code="404">Se o produto não for encontrado</response>
        [HttpPut("produto")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        [CustomResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizarAsync([FromBody] AtualizarProdutoRequest produto, [FromServices] IProdutoService produtoService)
        {
            if (ModelState.IsValid)
                return ResponseBadRequest();

            var response = await produtoService.AtualizaAsync(produto.ToProduto());

            return response > 0 ? ResponseOk("Produto atualizado com sucesso!") : ResponseNotFound("Erro ao atualizar produto.");
        }

        /// <summary>
        /// Atualizar Status Ativo/Inativo Produto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <param name="produtoService"></param>
        /// <returns></returns>
        /// <response code="200">Se o status do produto for atualizado</response>
        /// <response code="400">Se o status do produto não for atualizado</response>
        /// <response code="404">Se o produto não for encontrado</response>
        [HttpPatch("AtualizarStatus/{id}/{status}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        [CustomResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizarStatus(int id, bool status, [FromServices] IProdutoService produtoService)
        {
            if (id <= 0) return ResponseBadRequest();

            var response = await produtoService.AtualizarStatus(id, status);
            return response > 0 ? ResponseOk("Status Produto atualizado com sucesso!") : ResponseNotFound("Erro ao atualizar status.");
        }

        [HttpDelete("Deletar/{id}")]
        public async Task<IActionResult> DeletarPorId(int id, [FromServices] IProdutoService produtoService)
        {
            var retorno = await produtoService.DeletarPorId(id);
            return retorno > 0 ? ResponseOk("Produto excluído com sucesso!") : ResponseNotFound("Erro ao excluído status.");
        }
    }
}
