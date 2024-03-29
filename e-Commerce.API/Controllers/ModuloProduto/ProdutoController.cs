using e_Commerce.API.ViewModel.ModuloProduto;
using e_Commerce.Dominio.ModuloProduto;
using e_Commerce.Servico.ModuloProduto;

namespace e_Commerce.API.Controllers.ModuloProduto
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControladorBase<ListProdutoVM, FormProdutoVM, ViewProdutoVM, Produto>
    {
        readonly ServicoProduto service;
        readonly IMapper map;

        public ProdutoController(ServicoProduto service, IMapper map) : base(service, map)
        {
            this.service = service;
            this.map = map;
        }

        [HttpGet("nome/{nomeProduto}")]
        [ProducesResponseType(typeof(ListProdutoVM), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarPorNome(string nomeProduto)
        {
            var resultado = await service.SelecionarPorNome(nomeProduto);

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            List<ListProdutoVM> registrosVM = map.Map<List<ListProdutoVM>>(resultado.Value);
            //O que está em parenteses será convertido no que está entre <>

            return Ok(new
            {
                Sucesso = true,
                Dados = registrosVM
            });
        }

        [ProducesResponseType(typeof(FormProdutoVM), 200)]
        public override async Task<IActionResult> Inserir(FormProdutoVM registroVM)
        {
            return await base.Inserir(registroVM);
        }

        [ProducesResponseType(typeof(ListProdutoVM), 200)]
        public override async Task<IActionResult> SelecionarTodos()
        {
            return await base.SelecionarTodos();
        }

        [ProducesResponseType(typeof(ViewProdutoVM), 200)]
        public override async Task<IActionResult> SelecionarPorId(Guid id)
        {
            return await base.SelecionarPorId(id);
        }

        [ProducesResponseType(typeof(FormProdutoVM), 200)]
        public override Task<IActionResult> Editar(Guid id, FormProdutoVM registroVM)
        {
            return base.Editar(id, registroVM);
        }

        public override async Task<IActionResult> Deletar(Guid id)
        {
            return await base.Deletar(id);
        }
    }
}
