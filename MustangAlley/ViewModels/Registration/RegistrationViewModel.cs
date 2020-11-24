using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MustangAlley.ViewModels.Registration
{
    [Table("Registration")]
    public class RegistrationViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegistrationId { get; set; }

        //Person Details
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter a first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; }

        [Phone]
        [Display(Name = "Phone Number*")]
        [Required(ErrorMessage = "Please enter a phone number address")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please enter an email address")]
        public string Email { get; set; }

        [NotMapped]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "Email addresses do not match")]
        [Required(ErrorMessage = "Please re-enter your email address")]
        public string ConfirmEmail { get; set; }

        [NotMapped]
        public List<SelectListItem> TimeSlots { get; set; }
        
        [NotMapped]
        public List<SelectListItem> ShirtSizes { get; set; }

        [Display(Name = "Registering a Vehicle?")]
        public bool RegisteringVehicle { get; set; }
        [Display(Name = "Singing Up to Volunteer?")]
        public bool Volunteering { get; set; }

        #region Volunteer Properties

        [Display(Name = "Previous Volunteer?")]
        public bool PreviousVolunteer { get; set; }

        [Display(Name = "Previous Position")]
        public string PreviousPosition { get; set; }

        [Required]
        [Display(Name = "Preferred Timeslot")]
        public string PreferredTimeSlot { get; set; }

        [Display(Name = "Preferred Position")]
        public string PreferredPosition { get; set; }

        [Display(Name = "Second Preference")]
        public string SecondPreferredPosition { get; set; }

        [Required]
        [Display(Name = "T-Shirt Size")]
        public string ShirtSize { get; set; }

        #endregion

        #region Vehicle Properties

        [RegularExpression(@"19(6[4-9]|[789]\d)|20(0\d|1[0123456789]|2[01])", ErrorMessage = "Please enter a valid vehicle year between 1964 and 2021")]
        [Display(Name = "Vehicle Year")]
        [DefaultValue(0)]
        public int Year { get; set; }

        [Display(Name = "Body Style")]
        public string BodyStyle { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "License Plate Number")]
        public string LicensePlateNumber { get; set; }

        #endregion

    }
}
