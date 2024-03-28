namespace e_Commerce.Dominio.ModuloProduto
{
    public interface IRepositorioProduto : IRepositorioBase<Produto>
    {
        public Task<List<Produto>> SelecionarPorNome(string nomeProduto);
    }
}
