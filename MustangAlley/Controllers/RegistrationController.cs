using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MustangAlley.Services;
using MustangAlley.ViewModels.Registration;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

namespace MustangAlley.Controllers
{
    public class RegistrationController : Controller
    {
        private IRegistrationService service;
        
        public RegistrationController(IRegistrationService service)
        {
            this.service = service;
        }

        public IActionResult RegisterVehicle()
        {
            return View(service.GetRegistrationViewModel());
        }

        public IActionResult Volunteer()
        {
            return View(service.GetRegistrationViewModel());
        }

        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateRecaptcha]
        public IActionResult RegisterVehicle(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.RegisteringVehicle = true;
                service.SaveVehicleRegistration(model);
                return RedirectToAction("Confirmation");
            }

            return RedirectToAction("RegisterVehicle");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateRecaptcha]
        public IActionResult Volunteer(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.RegisteringVehicle = true;
                service.SaveVolunteerRegistration(model);
                return RedirectToAction("Confirmation");
            }

            return RedirectToAction("Volunteer");
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
