using e_Commerce.Dominio.ModuloItem;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Commerce.Infra.ModuloItem
{
    public class MapeadorItem : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");

            builder.Property(i => i.Id).ValueGeneratedNever();
           
            builder.Property(i => i.Qtd_Produto).IsRequired();

            builder.HasOne(i => i.Pedido)
                .WithMany(p => p.Itens).IsRequired()
                .HasForeignKey(i => i.Id_Pedido)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.Produto)
                .WithMany(p => p.Itens)
                .HasForeignKey(i => i.Id_Produto)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Usuario)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
