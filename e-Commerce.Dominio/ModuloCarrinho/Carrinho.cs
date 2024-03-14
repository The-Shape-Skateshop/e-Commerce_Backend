using e_Commerce.Dominio.ModuloCliente;
using e_Commerce.Dominio.ModuloItem;
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
        public List<Item> Itens { get; set; }
        #endregion

        public Guid Id_Cliente
        {
            get
            {
                return Cliente.Id;
            }
        }
        public List<Guid> Id_Item
        {
            get
            {
                return Itens.Select(c => c.Id).ToList<Guid>();
            }
        }

        public Carrinho()
        {
            Itens = new List<Item>();
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

        public void AdicionarProdutoNoCarrinho(Item item)
        {
            Itens.Add(item);
        }
    }
}
