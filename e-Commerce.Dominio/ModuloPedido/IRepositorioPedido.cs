namespace e_Commerce.Dominio.ModuloPedido
{
    public interface IRepositorioPedido : IRepositorioBase<Pedido>
    {
        public Task<List<Pedido>> SelecionarTodosPedidoDoCliente(Guid idCliente);
    }
}
