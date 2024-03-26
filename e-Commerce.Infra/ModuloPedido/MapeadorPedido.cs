using e_Commerce.Dominio.ModuloItem;
using e_Commerce.Dominio.ModuloPedido;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Commerce.Infra.ModuloPedido
{
    public class MapeadorPedido : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(p => p.Data).IsRequired();
            builder.Property(p => p.ValorTotal).HasColumnType("decimal(4, 2)").IsRequired();

            builder.HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos).IsRequired()
                .HasForeignKey(p => p.Id_Cliente)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
