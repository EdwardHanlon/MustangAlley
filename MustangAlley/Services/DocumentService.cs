using System.Drawing;
using MustangAlley.Services.Interfaces;
using MustangAlley.ViewModels.DashPlaque;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
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
            AddImage(gfx, @".\wwwroot\images\FPER_17_DreamCruise_4C_R01.png");

            // Get the FontResolver and load fonts.
            var fontResolver = FontResolver.Get;

            // Assign it to PDFsharp.
            GlobalFontSettings.FontResolver = fontResolver;

            fontResolver.AddFont("Ubuntu", XFontStyle.Regular, @".\wwwroot\fonts\ubuntufontfamily0.80\Ubuntu-C.ttf", true, true);
            XFont labelFont = new XFont("Ubuntu", 40, XFontStyle.BoldItalic);

            //X offset, Y offset, image width, image height
            gfx.DrawString(viewModel.Year.ToString() ?? "", labelFont, XBrushes.Black, new XRect(100, (page.Height / 2) + 50, page.Width, page.Height), XStringFormat.TopLeft);
            gfx.DrawString(viewModel.BodyStyle ?? "", labelFont, XBrushes.Black, new XRect((page.Width - (375 - viewModel.BodyStyle.Length)), (page.Height / 2) + 50, page.Width, page.Height), XStringFormat.TopLeft);
            gfx.DrawString(viewModel.Owner ?? "", labelFont, XBrushes.Black, new XRect(0, 0, page.Width, page.Height - 40), XStringFormat.BottomCenter);
            
            return document;
        }


        private void AddImage(XGraphics gfx, string imagePath)
        {
            //Add the image into the PDF
            var image = XImage.FromFile(imagePath);
            gfx.DrawImage(image, 225, 35, 350, 250);

            image.Dispose();
        }
    }
}
