using e_Commerce.Dominio.ModuloItem;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Commerce.Infra.ModuloItem
{
    public class MapeadorItem : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            throw new NotImplementedException();
        }
    }
}
