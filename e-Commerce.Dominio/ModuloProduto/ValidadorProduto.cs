namespace e_Commerce.Dominio.ModuloProduto
{
    public class ValidadorProduto : AbstractValidator<Produto>
    {
        public ValidadorProduto()
        {
            RuleFor(p => p.Nome)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Nome inválido. O nome deve conter no minimo 3 caracteres");

            RuleFor(p => p.Descricao)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .WithMessage("Descrição inválida, deve conter no minimo 5 caracteres");

            RuleFor(p => p.Valor)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.Imagem)
                .NotNull()
                .NotEmpty();


        }
    }
}
