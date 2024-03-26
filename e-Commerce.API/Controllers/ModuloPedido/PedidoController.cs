using e_Commerce.API.ViewModel.ModuloPedido;
using e_Commerce.Dominio.ModuloPedido;
using e_Commerce.Servico.ModuloPedido;

namespace e_Commerce.API.Controllers.ModuloPedido
{
    [Route("api/pedidos")]
    [ApiController]
    public class PedidoController : ControladorBase<ListPedidoVM, FormPedidoVM, ViewPedidoVM, Pedido>
    {
        readonly ServicoPedido service;
        readonly IMapper map;

        public PedidoController(ServicoPedido service, IMapper map) : base(service, map)
        {
            this.service = service;
            this.map = map;
        }

        [ProducesResponseType(typeof(FormPedidoVM), 200)]
        public override async Task<IActionResult> Inserir(FormPedidoVM registroVM)
        {
            return await base.Inserir(registroVM);
        }

        [ProducesResponseType(typeof(ListPedidoVM), 200)]
        public override async Task<IActionResult> SelecionarTodos()
        {
            return await base.SelecionarTodos();
        }

        [ProducesResponseType(typeof(ViewPedidoVM), 200)]
        public override async Task<IActionResult> SelecionarPorId(Guid id)
        {
            return await base.SelecionarPorId(id);
        }

        [ProducesResponseType(typeof(FormPedidoVM), 200)]
        public override Task<IActionResult> Editar(Guid id, FormPedidoVM registroVM)
        {
            return base.Editar(id, registroVM);
        }

        public override async Task<IActionResult> Deletar(Guid id)
        {
            return await base.Deletar(id);
        }
    }
}
