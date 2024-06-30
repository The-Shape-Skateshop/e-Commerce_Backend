using e_Commerce.API.Config.TratadoresErros;
using e_Commerce.Dominio.ModuloAuth;
using e_Commerce.Infra.Compartilhado;
using e_Commerce.Servico.ModuloAuth;
using Microsoft.AspNetCore.Identity;

namespace e_Commerce.API.Config.ExtensionMethods
{
    public static class IdentityConfigExtension
    {
        public static void ConfigurarIdentity(this IServiceCollection services)
        {
            services.AddTransient<ServicoAuth>();

            services.AddIdentity<Usuario, IdentityRole<Guid>>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<e_CommerceDbContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<eCommerceErrorDescriber>();
        }
    }
}
