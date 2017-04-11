using MustangAlley.ViewModels.Registration;

namespace MustangAlley.Repositories
{
    public interface IRegistrationRepository
    {
        void SaveRegistration(RegistrationViewModel model);
    }
}
