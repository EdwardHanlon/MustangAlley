using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MustangAlley.Services;
using MustangAlley.ViewModels.Contact;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

namespace MustangAlley.Controllers
{
    public class ContactController : Controller
    {
        private IEmailSender emailService;

        public ContactController(IEmailSender emailService)
        {
            this.emailService = emailService;
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult MessageConfirmation()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateRecaptcha]
        public IActionResult ContactUs(ContactUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                emailService.SendMessageReceivedEmail(model.EmailAddress, model.Name, model.Message);
                return RedirectToAction("MessageConfirmation");
            }

            return RedirectToAction("ContactUs");
        }
    }
}
