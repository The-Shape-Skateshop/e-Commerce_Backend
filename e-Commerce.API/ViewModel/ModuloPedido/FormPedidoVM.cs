using e_Commerce.API.ViewModel.ModuloItem;

namespace e_Commerce.API.ViewModel.ModuloPedido
{
    public class FormPedidoVM : FormBase<FormPedidoVM>
    {
        public decimal ValorTotal { get; set; }
        public DateOnly Data { get; set; }
        public Guid Id_Cliente { get; set; }
        public List<FormItemVM> Itens { get; set; }
    }
}
