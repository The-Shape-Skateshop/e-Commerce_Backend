using e_Commerce.API.ViewModel.ModuloPedido;
using e_Commerce.Dominio.ModuloPedido;
using e_Commerce.Servico.ModuloPedido;
using FluentResults;
using Microsoft.AspNetCore.Authorization;

namespace e_Commerce.API.Controllers.ModuloPedido
{
    [Authorize]
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
            Result<Pedido> resultado;

            Pedido pedido = map.Map<Pedido>(registroVM);

            resultado = await service.InserirAsync(pedido);

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            resultado = await service.MandarEmail(pedido);

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            return Ok();
        }

        public override async Task<IActionResult> SelecionarTodos()
        {
            return await base.SelecionarTodos();
        }

        [ProducesResponseType(typeof(ViewPedidoVM), 200)]
        public override async Task<IActionResult> SelecionarPorId(Guid id)
        {
            return await base.SelecionarPorId(id);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
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
