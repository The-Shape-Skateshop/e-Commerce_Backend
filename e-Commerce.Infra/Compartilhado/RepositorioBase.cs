using e_Commerce.Dominio.Compartilhado;

namespace e_Commerce.Infra.Compartilhado
{
    public class RepositorioBase<T> : IRepositorioBase<T>
        where T : EntidadeBase<T>
    {
        public Task CriarAsync(T registro)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> SelecionarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> SelecionarPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        void IRepositorioBase<T>.Deletar(T registro)
        {
            throw new NotImplementedException();
        }

        void IRepositorioBase<T>.Editar(T registro)
        {
            throw new NotImplementedException();
        }
    }
}
