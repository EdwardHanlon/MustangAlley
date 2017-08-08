using MustangAlley.ViewModels.DashPlaque;
using PdfSharp.Pdf;

namespace MustangAlley.Services.Interfaces
{
    public interface IDocumentService
    {
        PdfDocument GenerateDocument(DashPlaqueViewModel viewModel);
    }
}
