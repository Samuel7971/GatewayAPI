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
        [HttpGet("BuscarPorId/{id}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorIdAsync(int id, [FromServices] IProdutoService produtoService)
        {
            if (id <= 0) return ResponseBadRequest();

            var response = await produtoService.BuscarPorIdAsync(id);

            if (response is null) return ResponseNotFound();

            return ResponseOk(response);
        }

        [HttpPut("produto")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizarAsync([FromBody] AtualizarProdutoRequest produto, [FromServices] IProdutoService produtoService)
        {
            if (ModelState.IsValid)
                return ResponseBadRequest();

            var response = await produtoService.AtualizaAsync(produto.ToProduto());

            return response > 0 ? ResponseOk("Status Produto atualizado com sucesso!") : ResponseNotFound("Erro ao atualizar status.");
        }

        [HttpPatch("AtualizarStatus/{id}/{status}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarStatus(int id, bool status, [FromServices] IProdutoService produtoService)
        {
            if (id <= 0) return ResponseBadRequest();

            var response = await produtoService.AtualizarStatus(id, status);
            return response > 0 ? ResponseOk("Status Produto atualizado com sucesso!") : ResponseNotFound("Erro ao atualizar status.");
        }
    }
}
