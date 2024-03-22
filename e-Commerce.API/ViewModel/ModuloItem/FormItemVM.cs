namespace e_Commerce.API.ViewModel.ModuloItem
{
    public class FormItemVM : FormBase<FormItemVM>
    {
        public Guid Id_Pedido { get; set; }
        public Guid Id_Produto { get; set; }
        public int Qtd_Produto { get; set; }
    }
}
