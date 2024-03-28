using e_Commerce.API.ViewModel.ModuloProduto;

namespace e_Commerce.API.ViewModel.ModuloItem
{
    public class ViewItemVM : ViewBase<ViewItemVM>
    {
        public ViewProdutoVM Produto { get; set; }
        public int Qtd_Produto { get; set; }
    }
}
