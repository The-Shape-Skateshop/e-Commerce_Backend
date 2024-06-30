using e_Commerce.API.ViewModel.ModuloAuth;
using e_Commerce.Dominio.ModuloAuth;

namespace e_Commerce.API.Config.AutomapperConfig.ModuloAuth
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<RegistrarUsuarioViewModel, Usuario>()
                .ForMember(usuario => usuario.UserName, opt => opt.MapFrom(usuarioVM => usuarioVM.Email));
        }
    }
}
