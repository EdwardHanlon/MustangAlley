using Microsoft.Extensions.DependencyModel.Resolution;
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
            AddImage(gfx, @".\wwwroot\images\FPER_17_DreamCruise_4C_R01.png");
            
            // Draw the text
            XFont labelFont = new XFont("Verdana", 30, XFontStyle.Bold);

            //X offset, Y offset, image width, image height
            gfx.DrawString(viewModel.Year.ToString() ?? "", labelFont, XBrushes.Black, new XRect(100, (page.Height / 2) + 50, page.Width, page.Height), XStringFormat.TopLeft);
            gfx.DrawString(viewModel.BodyStyle ?? "", labelFont, XBrushes.Black, new XRect((page.Width - 300), (page.Height / 2) + 50, page.Width, page.Height), XStringFormat.TopLeft);
            gfx.DrawString(viewModel.Owner ?? "", labelFont, XBrushes.Black, new XRect(0, 0, page.Width, page.Height - 40), XStringFormat.BottomCenter);
            
            return document;
        }


        private void AddImage(XGraphics gfx, string imagePath)
        {
            //Add the image into the PDF
            var image = XImage.FromFile(imagePath);
            gfx.DrawImage(image, 225, 20, 350, 250);

            image.Dispose();
        }
    }
}
