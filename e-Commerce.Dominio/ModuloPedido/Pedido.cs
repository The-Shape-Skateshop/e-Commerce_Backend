using e_Commerce.Dominio.ModuloCliente;
using e_Commerce.Dominio.ModuloItem;

namespace e_Commerce.Dominio.ModuloPedido
{
    public class Pedido : EntidadeBase<Pedido>
    {
        #region Atributos que serão mapeados
        public decimal? ValorTotal { get; set; }
        public DateOnly? Data { get; set; }
        public Cliente? Cliente { get; set; }
        #endregion

        public List<Item>? Itens { get; set; }
        public List<Guid>? Id_Itens
        {
            get
            {
                return Itens.Select(c => c.Id).ToList<Guid>();
            }
        }

        public Guid? Id_Cliente { get; set; }

        public Pedido()
        {
            Itens = new List<Item>();
        }

        public Pedido(decimal valorTotal, DateOnly data, Cliente cliente) : this()
        {
            ValorTotal = valorTotal;
            Cliente = cliente;
            Data = data;
        }

        public Pedido(Guid id, decimal valorTotal, DateOnly data, Cliente cliente)
            : this(valorTotal, data, cliente)
        {
            Id = id;
        }

        public void AdicionarProdutoNoPedido(Item item)
        {
            Itens.Add(item);
        }
    }
}
