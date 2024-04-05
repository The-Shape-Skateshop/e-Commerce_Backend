﻿using e_Commerce.Dominio.Compartilhado;
using e_Commerce.Dominio.ModuloAuth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Reflection;

namespace e_Commerce.Infra.Compartilhado
{
    public class e_CommerceDbContext : IdentityDbContext<Usuario, IdentityRole<Guid>, Guid>, IContextoPersistencia
    {
        public e_CommerceDbContext(DbContextOptions options) : base(options)
        {

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

            

            base.OnModelCreating(modelBuilder);
        }
    }
}
