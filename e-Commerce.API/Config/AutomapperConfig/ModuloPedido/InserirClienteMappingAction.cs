//using e_Commerce.API.ViewModel.ModuloPedido;
//using e_Commerce.Dominio.ModuloPedido;

//namespace e_Commerce.API.Config.AutomapperConfig.ModuloPedido
//{
//    public class InserirClienteMappingAction : IMappingAction<FormPedidoVM, Pedido>
//    {
//        readonly IRepositorioCliente repCliente;

//        public InserirClienteMappingAction(IRepositorioCliente repCliente)
//        {
//            this.repCliente = repCliente;
//        }

//        public void Process(FormPedidoVM pedidoVM, Pedido pedido, ResolutionContext ctx)
//        {
//            pedido.Cliente = repCliente.SelecionarPorIdAsync(pedidoVM.Id_Cliente).Result;
//        }
//    }
//}
