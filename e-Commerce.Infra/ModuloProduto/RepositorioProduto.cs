using e_Commerce.Dominio.Compartilhado;
using e_Commerce.Dominio.ModuloProduto;

namespace e_Commerce.Infra.ModuloProduto
{
    public class RepositorioProduto : RepositorioBase<Produto>, IRepositorioProduto
    {
        public RepositorioProduto(IContextoPersistencia ctx) : base(ctx)
        {
        }

        public async Task<List<Produto>> SelecionarPorNome(string nomeProduto)
        {
            return await dbSet.Where(p => p.Nome.Contains(nomeProduto)).ToListAsync();
        }
    }
}
