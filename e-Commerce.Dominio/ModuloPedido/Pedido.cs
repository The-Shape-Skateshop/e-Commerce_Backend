using e_Commerce.Dominio.ModuloCliente;
using e_Commerce.Dominio.ModuloItem;

namespace e_Commerce.Dominio.ModuloPedido
{
    public class Pedido : EntidadeBase<Pedido>
    {
        #region Atributos que serão mapeados
        public decimal ValorTotal { get; set; }
        public DateOnly Data { get; set; }
        public string Descricao { get; set; }
        public Cliente Cliente { get; set; }
        #endregion

        public List<Item> Itens { get; set; }
        public List<Guid> Id_Item
        {
            get
            {
                return Itens.Select(c => c.Id).ToList<Guid>();
            }
        }

        public Guid Id_Cliente
        {
            get
            {
                return Cliente.Id;
            }
            set { }
        }

        public Pedido()
        {
            Itens = new List<Item>();
        }

        public Pedido(decimal valorTotal, string descricao, Cliente cliente) : this()
        {
            ValorTotal = valorTotal;
            Descricao = descricao;
            Cliente = cliente;
        }
        public Pedido(Guid id, decimal valorTotal, string descricao, Cliente cliente)
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
