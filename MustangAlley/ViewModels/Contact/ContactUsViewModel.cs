using System.ComponentModel.DataAnnotations;

namespace MustangAlley.ViewModels.Contact
{
    public class ContactUsViewModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Required(ErrorMessage = "Please enter an email address that we may reach you at")]
        public string EmailAddress { get; set; }

        [MaxLength(5000)]
        [Required(ErrorMessage = "Please enter a message")]
        public string Message { get; set; }
    }
}
