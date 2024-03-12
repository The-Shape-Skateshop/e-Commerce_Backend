namespace e_Commerce.API.Config.ExtensionMethods
{
    public static class ValidacaoConfigExtension
    {
        public static void ConfigurarValidacao(this IServiceCollection service)
        {
            service.Configure<ApiBehaviorOptions>(config =>
            {
                config.SuppressModelStateInvalidFilter = false;//serve para mascarar o erro
            });
        }
    }
}
