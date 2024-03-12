using e_Commerce.Dominio.ModuloProduto;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Commerce.Infra.ModuloProduto
{
    public class MapeadorProduto : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            throw new NotImplementedException();
        }
    }
}
