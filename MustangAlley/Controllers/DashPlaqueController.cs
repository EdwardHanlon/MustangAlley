using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MustangAlley.Services.Interfaces;
using MustangAlley.ViewModels.DashPlaque;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MustangAlley.Controllers
{
    public class DashPlaqueController : Controller
    {
        private IDocumentService documentService;

        public DashPlaqueController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public MemoryStream Generate(DashPlaqueViewModel model)
        {
            using (var stream = new MemoryStream())
            {
                var pdf = documentService.GenerateDocument(model);

                pdf.Save(stream);
                var pdfStreamData = stream.ToArray();
                stream.Close();
                stream.Dispose();

                return new MemoryStream(pdfStreamData, 0, pdfStreamData.Length);
            }
        }
    }
}
