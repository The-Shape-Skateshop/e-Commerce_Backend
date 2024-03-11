namespace e_Commerce.Dominio.Compartilhado
{
    public interface IContextoPersistencia
    {
        public Task GravarDadosAsync();
    }
}
