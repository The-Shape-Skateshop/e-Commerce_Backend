using e_Commerce.API.ViewModel.ModuloItem;
using e_Commerce.API.ViewModel.ModuloPedido;
using e_Commerce.Dominio.ModuloItem;
using e_Commerce.Dominio.ModuloPedido;
using e_Commerce.Dominio.ModuloProduto;

namespace e_Commerce.API.Config.AutomapperConfig.ModuloPedido
{
    public class InserirItemMappingAction : IMappingAction<FormPedidoVM, Pedido>
    {
        readonly IRepositorioProduto repProduto;

        public InserirItemMappingAction(IRepositorioProduto repProduto)
        {
            this.repProduto = repProduto;
        }

        public void Process(FormPedidoVM pedidoVM, Pedido pedido, ResolutionContext ctx)
        {
            pedido.Itens.Clear();

            var listaItem = pedidoVM.Itens.ToList();

            foreach (FormItemVM itemVM in listaItem)
            {
                Produto produto = repProduto.SelecionarPorIdAsync(itemVM.Id_Produto).Result;

                Item item = new Item(pedido, produto, itemVM.Qtd_Produto);

                pedido.AdicionarProdutoNoPedido(item);
            }
        }
    }
}
