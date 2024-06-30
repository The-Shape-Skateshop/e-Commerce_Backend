using e_Commerce.Dominio.ModuloAuth;
using Microsoft.AspNetCore.Identity;

namespace e_Commerce.Servico.ModuloAuth
{
    public class ServicoAuth : ServicoBase<Usuario, ValidadorAuth>
    {
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> sign;

        public ServicoAuth(UserManager<Usuario> userManager, SignInManager<Usuario> sign)
        {
            this.userManager = userManager;
            this.sign = sign;
        }

        public async Task<Result<Usuario>> RegistrarAsync(Usuario usuario, string senha)
        {
            Result resultado = Validar(usuario);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            var usuarioEncontrado = await userManager.FindByEmailAsync(usuario.Email);

            if (usuarioEncontrado != null)
            {
                return Result.Fail($"e-mail {usuarioEncontrado.Email} já cadastrado");
            }

            IdentityResult usuarioResult = await userManager.CreateAsync(usuario, senha);

            if (usuarioResult.Succeeded == false)
            {
                return Result.Fail(usuarioResult.Errors.Select(erro => new Error(erro.Description)));
            }

            return Result.Ok(usuario);
        }

        public async Task<Result<Usuario>> LoginAsync(string login, string senha)
        {
            var loginResult = await sign.PasswordSignInAsync(login, senha, false, true);

            var erros = new List<IError>();

            if (loginResult.IsLockedOut)
            {
                erros.Add(new Error("O acesso foi bloqueado"));
                return Result.Fail<Usuario>(erros);
            }

            if (!loginResult.Succeeded)
            {
                erros.Add(new Error("Login ou senha incorretos"));
                return Result.Fail<Usuario>(erros);
            }

            var usuario = await userManager.FindByNameAsync(login);

            return Result.Ok(usuario); ;
        }

        public async Task<Result<Usuario>> LogoutAsync()
        {
            await sign.SignOutAsync();

            return Result.Ok(); ;
        }
    }
}
