using e_Commerce.Dominio.ModuloProduto;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Commerce.Infra.ModuloProduto
{
    public class MapeadorProduto : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            
            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(p => p.Nome).HasColumnType("varchar(50)").IsRequired();
            builder.Property(p => p.Descricao).HasColumnType("varchar(200)").IsRequired();
            builder.Property(p => p.Imagem).HasColumnType("varchar(200)").IsRequired();
            builder.Property(p => p.Valor).HasColumnType("decimal(3, 2)").IsRequired();
        }
    }
}
