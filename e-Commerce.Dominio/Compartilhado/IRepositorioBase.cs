namespace e_Commerce.Dominio.Compartilhado
{
    public interface IRepositorioBase<T>
        where T : EntidadeBase<T>
    {
        public Task CriarAsync(T registro);
        public void Editar(T registro);
        public void Deletar(T registro);
        public Task<List<T>> SelecionarTodosAsync();
        public Task<T> SelecionarPorIdAsync(Guid id);
    }
}
