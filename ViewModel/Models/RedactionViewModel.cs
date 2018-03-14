using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Models
{
   public class RedactionViewModel
    {
        public int RedactionId { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(15, ErrorMessage = "Must be under 15 characters")]
        public string RedactionName { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(15, ErrorMessage = "Must be under 15 characters")]
        public string Country { get; set; }
    }
}
