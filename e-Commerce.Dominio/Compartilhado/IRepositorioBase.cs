namespace e_Commerce.Dominio.Compartilhado
{
    public interface IRepositorioBase<T>
        where T : EntidadeBase<T>
    {
        public Task CriarAsync(T registro);
        public Task EditarAsync(T registro);
        public Task DeletarAsync(T registro);
        public Task<List<T>> SelecionarAsync();
        public Task<T> SelecionarPorIdAsync(Guid id);
    }
}
