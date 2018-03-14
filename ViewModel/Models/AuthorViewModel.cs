using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViewModel.Models
{
    public class AuthorViewModel
    {

        public int AuthorId { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(30, ErrorMessage = "Must be under 30 characters")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(15, ErrorMessage = "Must be under 15 characters")]
        public string Country { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Range(1,2010, ErrorMessage = "Must be between 3 and 4")]
        public int YearOfBirth { get; set; }
    }
}