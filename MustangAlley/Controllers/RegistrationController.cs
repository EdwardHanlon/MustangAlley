using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            //Horrible hack work around post launch to fix validation error
            if (model.RegisteringVehicle == false)
            {
                ModelState.Root.GetModelStateForProperty("Year").ValidationState = ModelValidationState.Valid;
            }

            if (ModelState.IsValid)
            {
                model.Volunteering = true;
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
