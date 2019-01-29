using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLab.Models
{
    public class SimplePersonWithAttributes
    {
        [Display(Name = "Förnamn")]
        [Required(ErrorMessage = "Du måste ange ett namn!")]
        [StringLength(20, ErrorMessage = "Namnet måste vara mindre än 20 tecken")]
        public string Name { get; set; }

        [Display(Name = "Ålder")]
        [Required(ErrorMessage = "Du måste ange en ålder!")]
        [Range(0, 120,
        ErrorMessage = "Åldern måste vara mellan {1} och {2}.")]
        public int? Age { get; set; }

    }
}
