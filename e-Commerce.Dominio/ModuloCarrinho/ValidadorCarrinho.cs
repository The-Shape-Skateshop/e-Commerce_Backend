using e_Commerce.Dominio.ModuloCliente;

namespace e_Commerce.Dominio.ModuloCarrinho
{
    public class ValidadorCarrinho : AbstractValidator<Carrinho>
    {
        public ValidadorCarrinho()
        {
            RuleFor(c => c.Descricao)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .WithMessage("Descrição inválida, deve conter no minimo 5 caracteres");

            RuleFor(c => c.DataHora)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.ValorTotal)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.Cliente)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.Produtos)
                .NotNull()
                .NotEmpty();
        }
    }
}
