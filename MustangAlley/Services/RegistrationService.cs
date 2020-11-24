using System.Collections.Generic;
using System.Linq;
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
                TimeSlots = BuildTimeslotList().ToList(),
                ShirtSizes = BuildShirtsizeList().ToList()
            };
            
            return model;
        }

        private IEnumerable<string> GetTimeSlots()
        {
            //We have a variable size for the max # of volunteers at each time slot

            //Get the list of registrations for each slot, if any are 25 or over we want to remove them from the list
            var listOfFullSpots = repo.GetVolunteerRegistrationByTimeslot().Where(x => x.Value >= 25).Select(x => x.Key);
            
            var timeSlots = new List<string>
                            {
                                "6:00 AM - 10:00 AM",
                                "7:00 AM - 11:00 AM",
                                "8:00 AM - 12:00 PM",
                                "9:00 AM - 1:00 PM",
                                "10:00 AM - 2:00 PM",
                                "11:00 AM - 3:00 PM",
                                "12:00 PM - 4:00 PM",
                                "1:00 PM - 5:00 PM"
                            };

            return timeSlots.Where(x => !listOfFullSpots.Contains(x));
        }

        private IEnumerable<SelectListItem> BuildTimeslotList()
        {
            var openSlots = GetTimeSlots();

            foreach (var slot in openSlots)
                yield return new SelectListItem {Text = slot};
        }

        private IEnumerable<SelectListItem> BuildShirtsizeList()
        {
            return new List<SelectListItem>
                   {
                       new SelectListItem {Text = "S"},
                       new SelectListItem {Text = "M"},
                       new SelectListItem {Text = "L"},
                       new SelectListItem {Text = "XL"},
                       new SelectListItem {Text = "2XL"},
                       new SelectListItem {Text = "3XL"},
                       new SelectListItem {Text = "4XL"}
                   };
        }
    }
}
