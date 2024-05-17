using e_Commerce.Dominio.ModuloPedido;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.Text;

namespace e_Commerce.Infra.ModuloEmail
{
    public class GeradorPDF : IGeradorPDF
    {
        public byte[] GerarPdfEmail(Pedido pedido)
        {
            var message = GerarCorpoPdf(pedido);

            var document = new Document();

            using var memoryStream = new MemoryStream();

            try
            {
                PdfWriter.GetInstance(document, memoryStream);

                document.Open();

                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logocerto.png");

                Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);

                if (File.Exists(imagePath))
                {
                    Image imagem = Image.GetInstance(imagePath);
                    imagem.ScaleAbsolute(180f, 80f);
                    imagem.SetAbsolutePosition(390f, PageSize.A4.Height - 90f);

                    document.Add(imagem);
                }

                document.Add(new Paragraph());

                var titulo = new Paragraph("Detalhes do Pedido", new Font(Font.FontFamily.TIMES_ROMAN, 14, Font.BOLD))
                {
                    SpacingBefore = 10f,
                    SpacingAfter = 20f
                };
                document.Add(titulo);

                var estiloCorpo = new Font(Font.FontFamily.TIMES_ROMAN, 12);
                estiloCorpo.Color = BaseColor.DARK_GRAY;

                var paragraph = new Paragraph(message, estiloCorpo);
                document.Add(paragraph);

                var linha = new Chunk(new LineSeparator(0.5f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -2));
                document.Add(linha);

                var dataCriacao = new Paragraph($"Data de Criação: {DateTime.Now}", new Font(Font.FontFamily.TIMES_ROMAN, 10, Font.ITALIC))
                {
                    SpacingBefore = 20f,
                    Alignment = Element.ALIGN_RIGHT
                };
                document.Add(dataCriacao);

                document.Close();

                return memoryStream.ToArray();
            }
            catch
            {
                return null!;
            }
        }


        private static string GerarCorpoPdf(Pedido pedido)
        {
            var i = 0;
            var sb = new StringBuilder();

            sb.AppendLine($"Cliente: {pedido.Cliente.Nome}");
            sb.AppendLine($"ID do Pedido: {pedido.Id}");
            sb.AppendLine();
            sb.AppendLine("---- Itens do Pedido ----");
            foreach(var item in pedido.Itens)
            {
                sb.AppendLine($"{i + 1} - R$ {item.Produto.Valor} : {item.Produto.Nome}");
                i++;
            }
            sb.AppendLine();
            sb.AppendLine("--- Total ---");
            sb.AppendLine($"Valor Total: R$ {pedido.ValorTotal}");

            return sb.ToString();
        }
    }
}
