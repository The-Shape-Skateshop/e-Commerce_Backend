using e_Commerce.Dominio.Compartilhado;
using e_Commerce.Dominio.ModuloCliente;

namespace e_Commerce.Infra.ModuloCliente
{
    public class RepositorioCliente : RepositorioBase<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(IContextoPersistencia ctx) : base(ctx)
        {
        }

    }
}
