using e_Commerce.Dominio.ModuloCliente;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Commerce.Infra.ModuloCliente
{
    public class MapeadorCliente : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            throw new NotImplementedException();
        }
    }
}
