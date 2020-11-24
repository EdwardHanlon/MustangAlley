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
        private System.DateTime registrationCloseDate = new System.DateTime(2020, 8, 14);

        public RegistrationController(IRegistrationService service)
        {
            this.service = service;
        }

        public IActionResult RegisterVehicle()
        {
            return RedirectToAction("Index", "Home");

            if (System.DateTime.Now >= registrationCloseDate)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(service.GetRegistrationViewModel());
        }

        public IActionResult Volunteer()
        {
            return RedirectToAction("Index", "Home");

            if (System.DateTime.Now >= registrationCloseDate)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(service.GetRegistrationViewModel());
        }

        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateRecaptcha]
        public IActionResult RegisterVehicle(RegistrationViewModel model)
        {
            return RedirectToAction("Index", "Home");

            if (System.DateTime.Now >= registrationCloseDate)
            {
                return RedirectToAction("Index", "Home");
            }

            // I'm a horrible person and I will fix this later
            if (model.RegisteringVehicle == false)
            {
                ModelState.Root.GetModelStateForProperty("PreferredTimeSlot").ValidationState = ModelValidationState.Valid;
                ModelState.Root.GetModelStateForProperty("ShirtSize").ValidationState = ModelValidationState.Valid;
            }

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
            return RedirectToAction("Index", "Home");

            if (System.DateTime.Now >= registrationCloseDate)
            {
                return RedirectToAction("Index", "Home");
            }

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
