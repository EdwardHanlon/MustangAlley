using Microsoft.AspNetCore.Mvc;
using MustangAlley.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MustangAlley.Controllers
{
    public class SharedController : Controller
    {
        private IRegistrationService service;

        public SharedController(IRegistrationService service)
        {
            this.service = service;
        }

        //public PartialViewResult CarCount()
        //{
        //    var model = service.GetCarCountByYearViewModel();
        //    return PartialView(model);
        //}
    }
}
