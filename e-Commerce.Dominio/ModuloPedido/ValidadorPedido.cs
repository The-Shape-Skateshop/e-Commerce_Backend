namespace e_Commerce.Dominio.ModuloPedido
{
    public class ValidadorPedido : AbstractValidator<Pedido>
    {
        public ValidadorPedido()
        {
            RuleFor(p => p.Data)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.ValorTotal)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.Cliente)
                .NotNull()
                .NotEmpty();
        }
    }
}
