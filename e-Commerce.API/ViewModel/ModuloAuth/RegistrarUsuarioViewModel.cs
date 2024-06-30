namespace e_Commerce.API.ViewModel.ModuloAuth
{
    public class RegistrarUsuarioViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Senha { get; set; }
    }
}
