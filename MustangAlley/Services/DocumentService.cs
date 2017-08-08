using MustangAlley.Services.Interfaces;
using MustangAlley.ViewModels.DashPlaque;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace MustangAlley.Services
{
    public class DocumentService : IDocumentService
    {
        public PdfDocument GenerateDocument(DashPlaqueViewModel viewModel)
        {
            PdfDocument document = new PdfDocument();

            // Create an empty page
            PdfPage page = document.AddPage();

            page.Orientation = PageOrientation.Landscape;

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont labelFont = new XFont("Verdana", 30, XFontStyle.Bold);
            XFont valueFont = new XFont("Verdana", 20, XFontStyle.Bold);

            // Draw the text
            gfx.DrawString("YEAR", labelFont, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormat.TopLeft);
            gfx.DrawString("MODEL", labelFont, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormat.Center);
            gfx.DrawString("OWNER", labelFont, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormat.BottomCenter);

            return document;
        }
    }
}
