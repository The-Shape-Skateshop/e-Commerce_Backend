using e_Commerce.Dominio.Compartilhado;
using e_Commerce.Dominio.ModuloPedido;

namespace e_Commerce.Infra.ModuloPedido
{
    public class RepositorioPedido : RepositorioBase<Pedido>, IRepositorioPedido
    {
        public RepositorioPedido(IContextoPersistencia ctx) : base(ctx)
        {
            //TODO fazer o includes do item
        }
    }
}
