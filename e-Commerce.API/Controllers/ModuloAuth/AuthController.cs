using e_Commerce.API.Config.ExtensionMethods;
using e_Commerce.API.ViewModel.ModuloAuth;
using e_Commerce.Dominio.ModuloAuth;
using e_Commerce.Servico.ModuloAuth;

namespace e_Commerce.API.Controllers.ModuloAuth
{
    [Route("api/autenticar")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ServicoAuth service;
        private readonly IMapper map;

        public AuthController(ServicoAuth service, IMapper map)
        {

            this.service = service;
            this.map = map;
        }

        [HttpPost("registrar")]
        [ProducesResponseType(typeof(TokenViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Registrar(RegistrarUsuarioViewModel usuarioVM)
        {
            var usuario = this.map.Map<Usuario>(usuarioVM);

            var usuarioResult = await service.RegistrarAsync(usuario, usuarioVM.Senha);

            if (usuarioResult.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = usuarioResult.Errors.Select(result => result.Message)
                });
            }

            var token = usuario.GerarJwt(DateTime.Now.AddDays(5));

            return Ok(new
            {
                Sucesso = true,
                Dados = token
            });
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(TokenViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Login(AutenticarUsuarioViewModel usuarioVM)
        {
            var usuarioResult = await service.LoginAsync(usuarioVM.Email, usuarioVM.Senha);

            if (usuarioResult.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = usuarioResult.Errors.Select(result => result.Message)
                });
            }

            var usuario = usuarioResult.Value;

            var token = usuario.GerarJwt(DateTime.Now.AddDays(5));

            return Ok(new
            {
                Sucesso = true,
                Dados = token
            });
        }

        [HttpPost("logout")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Logout()
        {
            await service.LogoutAsync();

            return Ok();
        }

    }
}
