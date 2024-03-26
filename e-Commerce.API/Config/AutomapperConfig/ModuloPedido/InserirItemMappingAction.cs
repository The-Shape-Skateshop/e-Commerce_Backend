using e_Commerce.API.ViewModel.ModuloItem;
using e_Commerce.API.ViewModel.ModuloPedido;
using e_Commerce.Dominio.ModuloItem;
using e_Commerce.Dominio.ModuloPedido;
using e_Commerce.Dominio.ModuloProduto;
using e_Commerce.Servico.ModuloItem;

namespace e_Commerce.API.Config.AutomapperConfig.ModuloPedido
{
    public class InserirItemMappingAction : IMappingAction<FormPedidoVM, Pedido>
    {
        readonly ServicoItem serviceItem;
        readonly IRepositorioProduto repProduto;

        public InserirItemMappingAction(ServicoItem serviceItem, IRepositorioProduto repProduto)
        {
            this.serviceItem = serviceItem;
            this.repProduto = repProduto;
        }

        public void Process(FormPedidoVM pedidoVM, Pedido pedidoObj, ResolutionContext ctx)
        {
            var listaItem = pedidoVM.Itens.ToList();

            foreach (FormItemVM itemVM in listaItem)
            {
                Produto produto = repProduto.SelecionarPorIdAsync(itemVM.Id_Produto).Result;

                Item item = new Item(pedidoObj, produto, itemVM.Qtd_Produto);

                _ = serviceItem.InserirAsync(item);
            }
        }
    }
}
