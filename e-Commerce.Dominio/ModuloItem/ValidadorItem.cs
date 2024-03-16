namespace e_Commerce.Dominio.ModuloItem
{
    public class ValidadorItem : AbstractValidator<Item>
    {
        public ValidadorItem()
        {
            RuleFor(i => i.Pedido)
                .NotNull()
                .NotEmpty();

            RuleFor(i => i.Produto)
                .NotNull()
                .NotEmpty();

            RuleFor(i => i.Qtd_Produto)
                .NotNull()
                .NotEmpty();
        }
    }
}
