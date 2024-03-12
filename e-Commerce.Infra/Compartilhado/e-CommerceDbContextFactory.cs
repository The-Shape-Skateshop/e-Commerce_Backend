using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace e_Commerce.Infra.Compartilhado
{
    public class e_CommerceDbContextFactory : IDesignTimeDbContextFactory<e_CommerceDbContext>
    {
        public e_CommerceDbContext CreateDbContext(string[] args)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            string connectionString = config.GetConnectionString("PostgreSql");

            var optionsBuilder = new DbContextOptionsBuilder<e_CommerceDbContext>();

            optionsBuilder.UseNpgsql(connectionString);

            var dbcontext = new e_CommerceDbContext(optionsBuilder.Options);

            var migrador = new MigradorDb();

            migrador.AtualizarDb(dbcontext);

            return dbcontext;
        }
    }
}
