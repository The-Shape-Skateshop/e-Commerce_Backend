using e_Commerce.Dominio.ModuloCarrinho;

namespace e_Commerce.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        #region Atributos que serão mapeados
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public FormaPagamentoEnum TipoPag { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        #endregion

        public Carrinho Carrinho { get; set; }
        public Guid Id_Carrinho
        {
            get
            {
                return Carrinho.Id;
            }
        }

        public Cliente()
        {

        }

        public Cliente(string nome, string cpf, FormaPagamentoEnum tipoPag, string email, string telefone, Carrinho carrinho)
        {
            Nome = nome;
            Cpf = cpf;
            TipoPag = tipoPag;
            Email = email;
            Telefone = telefone;
            Carrinho = carrinho;
        }

        public Cliente(Guid id, string nome, string cpf, FormaPagamentoEnum tipoPag, string email, string telefone, Carrinho carrinho) 
            : this(nome, cpf, tipoPag, email, telefone, carrinho)
        {
            Id = id;
        }
    }
}
