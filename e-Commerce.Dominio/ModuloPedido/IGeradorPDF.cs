namespace e_Commerce.Dominio.ModuloPedido
{
    public interface IGeradorPDF
    {
        byte[] GerarPdfEmail(Pedido pedido);
    }
}
