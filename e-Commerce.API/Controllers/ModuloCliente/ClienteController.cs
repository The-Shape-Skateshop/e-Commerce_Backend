using e_Commerce.API.ViewModel.ModuloCliente;
using e_Commerce.Dominio.ModuloCliente;
using e_Commerce.Servico.ModuloCliente;

namespace e_Commerce.API.Controllers.ModuloCliente
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControladorBase<ListClienteVM, FormClienteVM, ViewClienteVM, Cliente>
    {
        readonly ServicoCliente service;
        readonly IMapper map;

        public ClienteController(ServicoCliente service, IMapper map) : base(service, map)
        {
            this.service = service;
            this.map = map;
        }

        [ProducesResponseType(typeof(ListClienteVM), 200)]
        public override async Task<IActionResult> Inserir(FormClienteVM registroVM)
        {
            Cliente registro = map.Map<Cliente>(registroVM);

            var resultado = await service.InserirAsync(registro);

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            ListClienteVM clienteVM = map.Map<ListClienteVM>(registro);

            return Ok(new
            {
                Sucesso = true,
                Dados = clienteVM
            });
        }

        [ProducesResponseType(typeof(ListClienteVM), 200)]
        public override async Task<IActionResult> SelecionarTodos()
        {
            return await base.SelecionarTodos();
        }

        [ProducesResponseType(typeof(ViewClienteVM), 200)]
        public override async Task<IActionResult> SelecionarPorId(Guid id)
        {
            return await base.SelecionarPorId(id);
        }

        [ProducesResponseType(typeof(FormClienteVM), 200)]
        public override Task<IActionResult> Editar(Guid id, FormClienteVM registroVM)
        {
            return base.Editar(id, registroVM);
        }

        public override async Task<IActionResult> Deletar(Guid id)
        {
            return await base.Deletar(id);
        }
    }
}
