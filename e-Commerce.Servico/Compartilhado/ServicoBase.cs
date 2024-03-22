using e_Commerce.Dominio.Compartilhado;

namespace e_Commerce.Servico.Compartilhado
{
    public class ServicoBase<T> : IServicoBase<T>
        where T : EntidadeBase<T>
    {
    }
}
