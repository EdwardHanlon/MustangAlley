using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MustangAlley.ViewModels.DashPlaque
{
    public class DashPlaqueViewModel
    {
        [RegularExpression(@"19(6[4-9]|[789]\d)|20(0\d|1[012345678])", ErrorMessage = "Please enter a valid vehicle year between 1964 and 2018")]
        [Display(Name = "Vehicle Year")]
        [DefaultValue(0)]
        public int Year { get; set; }

        [Display(Name = "Model")]
        public string BodyStyle { get; set; }

        [Display(Name = "Owner Name")]
        public string Owner { get; set; }
    }
}
