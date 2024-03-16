using e_Commerce.Dominio.ModuloItem;
using e_Commerce.Dominio.ModuloProduto;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Commerce.Infra.ModuloItem
{
    public class MapeadorItem : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");

            builder.Property(i => i.Id).ValueGeneratedNever();

            builder.HasOne(i => i.Pedido)
                .WithMany(p => p.Itens).IsRequired()
                .HasForeignKey(i => i.Id_Pedido)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(i => i.Qtd_Produto).IsRequired();

            builder.HasMany(i => i.Produtos)
           .WithMany(p => p.Itens)
           .UsingEntity<Item>(
                x => x.HasOne(i => i.Produtos)
                     .WithMany()
                     .HasForeignKey(i => i.Id_Produtos)
                     .OnDelete(DeleteBehavior.Cascade));

        }
    }
}
