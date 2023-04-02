using APIProduto.Controllers.Models;
using FluentValidation;

namespace APIProduto.Controllers.Validation
{
    public class ProdutoRequestValidador : AbstractValidator<AtualizarProdutoRequest>
    {
        public ProdutoRequestValidador()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id é requerido.") ;
            RuleFor(x => x.Nome)
                .NotEmpty().NotNull().WithMessage("O Nome do Produto é requerido.")
                .MinimumLength(5).WithMessage("Minimo de 5 caracteres para Nome.")
                .MaximumLength(100).WithMessage("Máximo de 100 caracteres para Nome.");
            RuleFor(x => x.Descricao)
                .NotNull().NotEmpty().WithMessage("Descrição do produto é requerido.")
                .MinimumLength(5).WithMessage("Minimo de 5 caracteres para descrição do produto.")
                .MaximumLength(100).WithMessage("Máximo de 100 caracteres para descrição do produto.");
        }

        //public static DifferentFromZero(AtualizarProdutoRequest atualizarProdutoRequest)
        //{
        //    if (atualizarProdutoRequest.Id == 0)
        //     return 
        //}
    }
}
