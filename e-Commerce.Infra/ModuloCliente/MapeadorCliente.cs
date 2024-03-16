using e_Commerce.Dominio.ModuloCliente;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Commerce.Infra.ModuloCliente
{
    public class MapeadorCliente : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.Property(c => c.Nome).HasColumnType("varchar(50)").IsRequired();
            builder.Property(c => c.Cpf).HasColumnType("varchar(50)").IsRequired();
            builder.Property(c => c.Email).HasColumnType("varchar(50)").IsRequired();
            builder.Property(c => c.Telefone).HasColumnType("varchar(50)").IsRequired();
        }
    }
}
