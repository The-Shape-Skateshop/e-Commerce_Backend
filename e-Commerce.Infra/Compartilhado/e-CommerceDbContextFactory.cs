using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace e_Commerce.Infra.Compartilhado
{
    public class e_CommerceDbContextFactory : IDesignTimeDbContextFactory<e_CommerceDbContext>
    {
        public e_CommerceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<e_CommerceDbContext>();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = config.GetConnectionString("PostgreSql");

            builder.UseNpgsql(connectionString);

            var dbcontext = new e_CommerceDbContext(builder.Options);

            var migrador = new MigradorDb();

            migrador.AtualizarDb(dbcontext);

            return dbcontext;
        }
    }
}
