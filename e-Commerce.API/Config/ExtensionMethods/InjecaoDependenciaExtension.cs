using e_Commerce.API.Config.AutomapperConfig.ModuloPedido;
using e_Commerce.API.Config.TratadoresErros;
using e_Commerce.Dominio.Compartilhado;
using e_Commerce.Dominio.ModuloCliente;
using e_Commerce.Dominio.ModuloItem;
using e_Commerce.Dominio.ModuloPedido;
using e_Commerce.Dominio.ModuloProduto;
using e_Commerce.Infra.Compartilhado;
using e_Commerce.Infra.ModuloCliente;
using e_Commerce.Infra.ModuloEmail;
using e_Commerce.Infra.ModuloItem;
using e_Commerce.Infra.ModuloPedido;
using e_Commerce.Infra.ModuloProduto;
using e_Commerce.Servico.ModuloCliente;
using e_Commerce.Servico.ModuloPedido;
using e_Commerce.Servico.ModuloProduto;
using Microsoft.EntityFrameworkCore;

namespace e_Commerce.API.Config.ExtensionMethods
{
    public static class InjecaoDependencia
    {
        public static void ConfigurarInjecaoDependencia(this IServiceCollection services, IConfiguration config)
        {
            string connectionString = config.GetConnectionString("PostgreSql");

            services.AddDbContext<IContextoPersistencia, e_CommerceDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseNpgsql(connectionString);
            });

            //Registrando esse contexto com a interface IContextoPersistencia
            //Em outros lugares do código, pode injetar IContextoPersistencia e obter uma instância de e_CommerceDbContext
            services.AddTransient<IGeradorEmail, GeradorEmail>();
            services.AddTransient<IGeradorPDF, GeradorPDF>();
            services.AddTransient<ManipuladorExcecoes>();

            services.AddTransient<IRepositorioPedido, RepositorioPedido>();
            services.AddTransient<InserirClienteMappingAction>();
            services.AddTransient<InserirItemMappingAction>();
            services.AddTransient<ServicoPedido>();

            services.AddTransient<IRepositorioCliente, RepositorioCliente>();
            services.AddTransient<ServicoCliente>();

            services.AddTransient<IRepositorioProduto, RepositorioProduto>();
            services.AddTransient<ServicoProduto>();

            services.AddTransient<IRepositorioItem, RepositorioItem>();
        }
    }
}
