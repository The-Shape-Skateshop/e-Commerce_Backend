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

        // Fazer endpoint SelecionarPorNome()

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
