namespace e_Commerce.API.ViewModel.ModuloAuth
{
    public class UsuarioTokenViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public UsuarioTokenViewModel(Guid id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

    }
}
