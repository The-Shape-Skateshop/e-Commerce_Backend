using e_Commerce.API.Config.AutomapperConfig.Compartilhado;
using e_Commerce.API.Config.ExtensionMethods;
using e_Commerce.API.Config.Filters;
using e_Commerce.API.Config.TratadoresErros;

namespace e_Commerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors();

            builder.Services.ConfigurarValidacao();

            //============== Logs =================
            builder.Services.ConfigurarSerilog(builder.Logging);
            //=====================================

            //============ Extension ==============
            builder.Services.ConfigurarSwaggerExtension();
            builder.Services.ConfigurarInjecaoDependencia(builder.Configuration);

            builder.Services.ConfigurarIdentity();
            //=====================================

            //============= Mappers ===============
            builder.Services.ConfigurarAutoMapper();
            //=====================================

            //======= Autentica��o Config ========= 
            builder.Services.ConfigurarValidacaoToken(); //configura��o do middleware que ira validar o token, a partir de qualquer request
            //=====================================

            //== Controllers, Filtros e Exce��es ==
            builder.Services.AddControllers(config =>
            {
                config.Filters.Add<LogActionFilter>();
            });

            var app = builder.Build();

            app.UseMiddleware<ManipuladorExcecoes>();
            //=====================================

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}