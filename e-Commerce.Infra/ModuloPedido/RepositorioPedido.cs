using e_Commerce.Dominio.Compartilhado;
using e_Commerce.Dominio.ModuloPedido;

namespace e_Commerce.Infra.ModuloPedido
{
    public class RepositorioPedido : RepositorioBase<Pedido>, IRepositorioPedido
    {
        public RepositorioPedido(IContextoPersistencia ctx) : base(ctx)
        {
            //TODO fazer o includes do item no selecionar todos
        }

        public override async Task<Pedido> SelecionarPorIdAsync(Guid id)
        {
            return await dbSet.Where(p => p.Id == id).Include(p => p.Itens).ThenInclude(i => i.Produto).FirstOrDefaultAsync();
        }

        public override async Task<List<Pedido>> SelecionarTodosAsync()
        {
            return await dbSet.Include(p => p.Itens).ThenInclude(i => i.Produto).ToListAsync();
        }
    }
}
 