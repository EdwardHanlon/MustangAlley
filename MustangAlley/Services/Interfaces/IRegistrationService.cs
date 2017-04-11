using System.Collections.Generic;
using MustangAlley.ViewModels.Registration;

namespace MustangAlley.Services
{
    public interface IRegistrationService
    {
        void SaveVehicleRegistration(RegistrationViewModel model);
        void SaveVolunteerRegistration(RegistrationViewModel model);
        //CarRegistrationCountViewModel GetCarCountByYearViewModel();
        RegistrationViewModel GetRegistrationViewModel();
    }
}
