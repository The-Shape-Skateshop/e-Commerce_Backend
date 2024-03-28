using e_Commerce.API.ViewModel.ModuloCliente;
using e_Commerce.API.ViewModel.ModuloItem;
using e_Commerce.Dominio.ModuloPedido;

namespace e_Commerce.API.ViewModel.ModuloPedido
{
    public class ViewPedidoVM : ViewBase<ViewPedidoVM>
    {
        public decimal ValorTotal { get; set; }
        public DateOnly Data { get; set; }
        public List<ViewItemVM> Itens { get; set; }
    }
}
