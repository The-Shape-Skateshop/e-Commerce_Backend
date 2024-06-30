namespace e_Commerce.Dominio.ModuloAuth
{
    public class ValidadorAuth : AbstractValidator<Usuario>
    {
        public ValidadorAuth()
        {
            RuleFor(u => u.Nome)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Nome inválido. O nome deve conter no minimo 3 caracteres");

            RuleFor(u => u.Cpf)
                .NotNull()
                .NotEmpty()
                .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")
                .WithMessage("CPF inválido. O formato deve ser xxx.xxx.xxx-xx");

            RuleFor(u => u.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("Email inválido. O formato deve ser 'exemplo@extensao.com'");

            RuleFor(u => u.Telefone)
                .NotEmpty()
                .NotEmpty()
                .Matches(@"^(\(\d{2}\)\s?\d{5}-\d{4}|\d{10})$")
                .WithMessage("Telefone inválido. O formato deve ser (99)99999-9999");

            RuleFor(u => u.DataNascimento)
                .NotNull()
                .NotEmpty();

            RuleFor(u => u.Senha)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}
