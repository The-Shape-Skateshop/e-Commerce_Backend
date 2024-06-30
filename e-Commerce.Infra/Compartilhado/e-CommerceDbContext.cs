using e_Commerce.Dominio.Compartilhado;
using e_Commerce.Dominio.ModuloAuth;
using e_Commerce.Dominio.ModuloItem;
using e_Commerce.Dominio.ModuloPedido;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Reflection;

namespace e_Commerce.Infra.Compartilhado
{
    public class e_CommerceDbContext : IdentityDbContext<Usuario, IdentityRole<Guid>, Guid>, IContextoPersistencia
    {
        private Guid usuario_id;
        public e_CommerceDbContext(DbContextOptions options, ITenantProvider tenantProvider = null) : base(options)
        {
            if (tenantProvider != null)
            {
                this.usuario_id = tenantProvider.Usuario_id;
            }
        }

        public async Task GravarDadosAsync()
        {
            await SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create((x) =>
            {
                x.AddSerilog(Log.Logger);
            });

            optionsBuilder.UseLoggerFactory(loggerFactory);

            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly binario = typeof(e_CommerceDbContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(binario);

            modelBuilder.Entity<Pedido>().HasQueryFilter(x => x.UsuarioId == usuario_id);
            modelBuilder.Entity<Item>().HasQueryFilter(x => x.UsuarioId == usuario_id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
