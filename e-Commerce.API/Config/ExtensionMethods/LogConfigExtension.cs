using Serilog;

namespace e_Commerce.API.Config.ExtensionMethods
{
    public static class LogConfigExtension
    {
        public static void ConfigurarSerilog(this IServiceCollection services, ILoggingBuilder logging)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Iniciando Aplicação...");

            logging.ClearProviders();//limpa os provider de log da microsoft

            services.AddSerilog(Log.Logger);
        }
    }
}
