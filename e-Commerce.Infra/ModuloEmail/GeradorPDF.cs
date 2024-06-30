using e_Commerce.Dominio.ModuloPedido;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.IO;
using System.Text;

namespace e_Commerce.Infra.ModuloEmail
{
    public class GeradorPDF : IGeradorPDF
    {
        public byte[] GerarPdfEmail(Pedido pedido)
        {
            var message = GerarCorpoPdf(pedido);

            using (var memoryStream = new MemoryStream())
            {
                try
                {
                    var writer = new PdfWriter(memoryStream);
                    var pdf = new PdfDocument(writer);
                    var document = new Document(pdf);

                    string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logocerto.png");

                    if (File.Exists(imagePath))
                    {
                        var logo = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(imagePath));
                        logo.ScaleAbsolute(180f, 80f);
                        logo.SetFixedPosition(390f, PageSize.A4.GetHeight() - 90f);

                        document.Add(logo);
                    }

                    document.Add(new Paragraph());

                    var titulo = new Paragraph("Detalhes do Pedido")
                                    .SetFont(PdfFontFactory.CreateFont("Times-Roman"))
                                    .SetFontSize(14)
                                    .SetBold()
                                    .SetMarginBottom(20f);

                    document.Add(titulo);

                    var estiloCorpo = PdfFontFactory.CreateFont("Times-Roman");
                    var paragraph = new Paragraph(message)
                                        .SetFont(estiloCorpo)
                                        .SetFontSize(12)
                                        .SetFontColor(iText.Kernel.Colors.ColorConstants.DARK_GRAY);

                    document.Add(paragraph);

                    var linha = new LineSeparator(new SolidLine(0.5f));
                    document.Add(linha);

                    var dataCriacao = new Paragraph($"Data de Criação: {DateTime.Now}")
                                            .SetFont(PdfFontFactory.CreateFont("Times-Roman"))
                                            .SetFontSize(10)
                                            .SetItalic()
                                            .SetTextAlignment(TextAlignment.RIGHT)
                                            .SetMarginTop(20f);

                    document.Add(dataCriacao);

                    document.Close();

                    return memoryStream.ToArray();
                }
                catch
                {
                    return null;
                }
            }
        }

        private static string GerarCorpoPdf(Pedido pedido)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Cliente: {pedido.Usuario.Nome}");
            sb.AppendLine($"ID do Pedido: {pedido.Id}");
            sb.AppendLine();
            sb.AppendLine("---- Itens do Pedido ----");
            foreach (var item in pedido.Itens)
            {
                sb.AppendLine($"{item.Produto.Nome} - R$ {item.Produto.Valor}");
            }
            sb.AppendLine();
            sb.AppendLine("--- Total ---");
            sb.AppendLine($"Valor Total: R$ {pedido.ValorTotal}");

            return sb.ToString();
        }
    }
}
