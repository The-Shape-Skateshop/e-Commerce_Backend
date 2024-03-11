namespace e_Commerce.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(c => c.Nome)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Nome inválido. O nome deve conter no minimo 3 caracteres");

            RuleFor(c => c.Cpf)
                .NotNull()
                .NotEmpty()
                .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")
                .WithMessage("CPF inválido. O formato deve ser xxx.xxx.xxx-xx");

            RuleFor(c => c.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("Email inválido. O formato deve ser 'exemplo@extensao.com'");

            RuleFor(c => c.Telefone)
                .NotEmpty()
                .NotEmpty()
                .Matches(@"^(\(\d{2}\)\s?\d{5}-\d{4}|\d{10})$")
                .WithMessage("Telefone inválido. O formato deve ser (99)99999-9999");

            RuleFor(c => c.TipoPag)
                .NotEmpty()
                .NotEmpty();
        }
    }
}
