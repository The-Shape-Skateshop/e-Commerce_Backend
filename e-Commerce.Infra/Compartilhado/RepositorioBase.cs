using e_Commerce.Dominio.Compartilhado;

namespace e_Commerce.Infra.Compartilhado
{
    public class RepositorioBase<T> : IRepositorioBase<T>
        where T : EntidadeBase<T>
    {
        protected DbSet<T> dbSet;
        private readonly DbContext dbContext;

        public RepositorioBase(IContextoPersistencia ctx)
        {
            dbContext = (e_CommerceDbContext)ctx;
            dbSet = dbContext.Set<T>();
        }

        public async Task CriarAsync(T registro)
        {
            await dbSet.AddAsync(registro);
        }

        public async Task<List<T>> SelecionarTodosAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> SelecionarPorIdAsync(Guid id)
        {
            return await dbSet.SingleOrDefaultAsync(x => x.Id == id);
        }

        void IRepositorioBase<T>.Deletar(T registro)
        {
            dbSet.Remove(registro);
        }

        void IRepositorioBase<T>.Editar(T registro)
        {
            dbSet.Update(registro);
        }
    }
}
