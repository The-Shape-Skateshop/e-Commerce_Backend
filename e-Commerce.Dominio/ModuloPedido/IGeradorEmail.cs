namespace e_Commerce.Dominio.ModuloPedido
{
    public interface IGeradorEmail
    {
        Result EnviarEmail(Pedido pedido, byte[] bytesAnexo = null!);
    }
}
