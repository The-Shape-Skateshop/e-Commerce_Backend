namespace e_Commerce.API.ViewModel.ModuloCliente
{
    public class FormClienteVM : FormBase<FormClienteVM>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public DateOnly DataNascimento { get; set; }
    }
}
