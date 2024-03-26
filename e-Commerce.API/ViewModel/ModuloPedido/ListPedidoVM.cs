using e_Commerce.Dominio.ModuloPedido;

namespace e_Commerce.API.ViewModel.ModuloPedido
{
    public class ListPedidoVM : ListBase<ListPedidoVM>
    {
        public decimal ValorTotal { get; set; }
        public DateOnly Data { get; set; }
        public List<Guid> Id_Itens { get; set; }
    }
}
