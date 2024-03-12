using e_Commerce.Dominio.ModuloCarrinho;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Commerce.Infra.ModuloCarrinho
{
    public class MapeadorCarrinho : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            throw new NotImplementedException();
        }
    }
}
