using e_Commerce.API.ViewModel.ModuloItem;
using e_Commerce.Dominio.ModuloItem;

namespace e_Commerce.API.Config.AutomapperConfig.ModuloItem
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            //CreateMap<O que é, O que vai virar>();
            //Aqui precisa de um mapping action
            CreateMap<Item, ListItemVM>();
            CreateMap<Item, ViewItemVM>();
            CreateMap<FormItemVM, Item>();
        }
    }
}
