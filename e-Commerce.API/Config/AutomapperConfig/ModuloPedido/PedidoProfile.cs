using e_Commerce.API.ViewModel.ModuloPedido;
using e_Commerce.Dominio.ModuloPedido;

namespace e_Commerce.API.Config.AutomapperConfig.ModuloPedido
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            //Aqui precisa de um mapping action
            CreateMap<Pedido, ListPedidoVM>();
            CreateMap<Pedido, ViewPedidoVM>();
            CreateMap<FormPedidoVM, Pedido>();
        }
    }
}
