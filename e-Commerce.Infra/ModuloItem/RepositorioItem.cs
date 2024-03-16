using e_Commerce.Dominio.Compartilhado;
using e_Commerce.Dominio.ModuloItem;

namespace e_Commerce.Infra.ModuloItem
{
    public class RepositorioItem : RepositorioBase<Item>, IRepositorioItem
    {
        public RepositorioItem(IContextoPersistencia ctx) : base(ctx)
        {
        }
    }
}
