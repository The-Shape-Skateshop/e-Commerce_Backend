using e_Commerce.Dominio.ModuloCliente;
using e_Commerce.Dominio.ModuloProduto;

namespace e_Commerce.Dominio.ModuloCarrinho
{
    public class Carrinho : EntidadeBase<Carrinho>
    {
        #region Atributos que serão mapeados
        public decimal ValorTotal {  get; set; }
        public DateOnly Data { get; set; }
        public string Descricao { get; set; }
        public Cliente Cliente { get; set; }
        public List<Produto> Produtos { get; set; }
        #endregion

        public Guid Id_Cliente
        {
            get
            {
                return Cliente.Id;
            }
        }
        public List<Guid> Id_Produtos
        {
            get
            {
                return Produtos.Select(c => c.Id).ToList<Guid>();
            }
        }

        public Carrinho()
        {
            Produtos = new List<Produto>();
        }

        public Carrinho(decimal valorTotal, string descricao, Cliente cliente) : this()
        {
            ValorTotal = valorTotal;
            Descricao = descricao;
            Cliente = cliente;
        }
        public Carrinho(Guid id, decimal valorTotal, string descricao, Cliente cliente) 
            : this(valorTotal, descricao, cliente)
        {
            Id = id;
        }

        public void AdicionarProdutoNoCarrinho(Produto produto)
        {
            Produtos.Add(produto);
        }
    }
}
