using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MustangAlley.Repositories;
using MustangAlley.ViewModels.Registration;

namespace MustangAlley.Services
{
    public class RegistrationService : IRegistrationService
    {
        private IRegistrationRepository repo;
        private IEmailSender emailService;

        public RegistrationService(IRegistrationRepository repository, IEmailSender emailSender)
        {
            repo = repository;
            emailService = emailSender;
        }

        public void SaveVehicleRegistration(RegistrationViewModel model)
        {
            repo.SaveRegistration(model);
            emailService.SendEmail(model.Email);
        }

        public void SaveVolunteerRegistration(RegistrationViewModel model)
        {
            model.Volunteering = true;
            repo.SaveRegistration(model);
            emailService.SendEmail(model.Email);
        }
        
        public RegistrationViewModel GetRegistrationViewModel()
        {
            var model = new RegistrationViewModel
            {
                PreviousVolunteer = false,
                RegisteringVehicle = false,
                TimeSlots = new List<SelectListItem>
                            {
                                new SelectListItem { Text =  "6:00 AM - 10:00 AM" },
                                new SelectListItem { Text =  "7:00 AM - 11:00 AM" },
                                new SelectListItem { Text =  "8:00 AM - 12:00 PM" },
                                new SelectListItem { Text =  "9:00 AM - 1:00 PM"  },
                                new SelectListItem { Text =  "10:00 AM - 2:00 PM" },
                                new SelectListItem { Text =  "11:00 AM - 3:00 PM" },
                                new SelectListItem { Text =  "12:00 PM - 4:00 PM" },
                                new SelectListItem { Text =  "1:00 PM - 5:00 PM"  }
                            },
                
                ShirtSizes = new List<SelectListItem>
                             {
                                 new SelectListItem { Text =  "S" },
                                 new SelectListItem { Text =  "M" },
                                 new SelectListItem { Text =  "L" },
                                 new SelectListItem { Text =  "XL" },
                                 new SelectListItem { Text =  "2XL" },
                                 new SelectListItem { Text =  "3XL" },
                                 new SelectListItem { Text =  "4XL" }
                             }
            };
            
            return model;
        }
    }
}
