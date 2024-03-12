namespace e_Commerce.Dominio.Compartilhado
{
    public interface IRepositorioBase<T>
        where T : EntidadeBase<T>
    {
        public Task CriarAsync(T registro);
        public void EditarAsync(T registro);
        public void DeletarAsync(T registro);
        public Task<List<T>> SelecionarAsync();
        public Task<T> SelecionarPorIdAsync(Guid id);
    }
}
