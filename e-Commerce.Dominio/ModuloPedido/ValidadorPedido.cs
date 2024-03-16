namespace e_Commerce.Dominio.ModuloPedido
{
    public class ValidadorPedido : AbstractValidator<Pedido>
    {
        public ValidadorPedido()
        {
            RuleFor(c => c.Descricao)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .WithMessage("Descrição inválida, deve conter no minimo 5 caracteres");

            RuleFor(c => c.Data)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.ValorTotal)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.Cliente)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.Itens)
                .NotNull()
                .NotEmpty();
        }
    }
}
