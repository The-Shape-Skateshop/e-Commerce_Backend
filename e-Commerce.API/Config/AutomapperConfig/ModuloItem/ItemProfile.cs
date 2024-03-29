using e_Commerce.API.ViewModel.ModuloItem;
using e_Commerce.Dominio.ModuloItem;

namespace e_Commerce.API.Config.AutomapperConfig.ModuloItem
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            //CreateMap<O que é, O que vai virar>();
            //Precisa mesmo desse profile?
            CreateMap<Item, ViewItemVM>();
            CreateMap<FormItemVM, Item>();

        }
    }
}
