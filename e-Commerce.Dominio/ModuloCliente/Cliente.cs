using e_Commerce.Dominio.ModuloPedido;

namespace e_Commerce.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        #region Atributos que serão mapeados
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Senha { get; set; }
        public DateOnly DataNascimento { get; set; }
        #endregion

        public List<Pedido>? Pedidos { get; set; }
        public List<Guid>? Id_Pedidos
        {
            get
            {
                return Pedidos.Select(p => p.Id).ToList<Guid>();
            }
        }

        public Cliente()
        {

        }

        public Cliente(string nome, string cpf, string email, string telefone, string senha) : this()
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            Senha = senha;

        }

        public Cliente(Guid id, string nome, string cpf, string email, string telefone, string senha) 
            : this(nome, cpf, email, telefone, senha)
        {
            Id = id;
        }
    }
}
