using Microsoft.AspNetCore.Identity;
using Taikandi;

namespace e_Commerce.Dominio.ModuloAuth
{
    public class Usuario : IdentityUser<Guid>
    {
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string? Senha { get; set; }

        public Usuario()
        {
            Id = SequentialGuid.NewGuid();
        }
    }
}
