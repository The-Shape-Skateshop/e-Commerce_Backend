using e_Commerce.API.ViewModel.ModuloCliente;
using e_Commerce.Dominio.ModuloCliente;

namespace e_Commerce.API.Config.AutomapperConfig.ModuloCliente
{
    public class ClienteProfile : Profile 
    {
        public ClienteProfile()
        {
            //Aqui precisa de um mapping action
            CreateMap<Cliente, ListClienteVM>();
            CreateMap<Cliente, ViewClienteVM>();
            CreateMap<FormClienteVM, Cliente>();
        }
    }
}
