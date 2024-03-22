using e_Commerce.Dominio.Compartilhado;
using FluentResults;

namespace e_Commerce.Servico.Compartilhado
{
    public interface IServicoBase<T> 
        where T : EntidadeBase<T>
    {
        public Task<Result<T>> CriarAsync(T registro);
        public Task<Result<T>> EditarAsync(T registro);
        public Task<Result> DeletarPorIdAsync(Guid id);
        public Task<Result> DeletarPorRegistroAsync(T registro);
        public Task<Result<List<T>>> SelecionarTodosAsync();
        public Task<Result<T>> SelecionarPorIdAsync(Guid id);
    }
}
