using e_Commerce.API.Config.AutomapperConfig.ModuloAuth;
using e_Commerce.API.Config.AutomapperConfig.ModuloItem;
using e_Commerce.API.Config.AutomapperConfig.ModuloPedido;
using e_Commerce.API.Config.AutomapperConfig.ModuloProduto;

namespace e_Commerce.API.Config.AutomapperConfig.Compartilhado
{
    public static class AutoMapperConfigExtension
    {
        public static void ConfigurarAutoMapper(this IServiceCollection service)
        {
            service.AddAutoMapper(opt =>
            {
                opt.AddProfile<ItemProfile>();
                opt.AddProfile<ProdutoProfile>();
                opt.AddProfile<PedidoProfile>();
                opt.AddProfile<UsuarioProfile>();
            });
        }
    }
}
