using e_Commerce.API.ViewModel.ModuloProduto;
using e_Commerce.Dominio.ModuloProduto;

namespace e_Commerce.API.Config.AutomapperConfig.ModuloProduto
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ListProdutoVM>();
            CreateMap<Produto, ViewProdutoVM>();
            CreateMap<FormProdutoVM, Produto>();
        }
    }
}
