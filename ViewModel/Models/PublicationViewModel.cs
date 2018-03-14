using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Models
{
    public class PublicationViewModel
    {
        public int PublicationId { get; set; }

        
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(30, ErrorMessage = "Must be under 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(30, ErrorMessage = "Must be under 30 characters")]
        public string Title { get; set; }

         
        public string RedactionName { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Range(1, 100, ErrorMessage = "Must be between 1 and 100")]
        public int Tome { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Range(1, 500, ErrorMessage = "Must be between 1 and 500")]
        public int Pages { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Range(1, 500, ErrorMessage = "Must be between 1 and 500")]
        public int Price { get; set; }

        public byte [] Image { get; set; }

        public string Image64 { get; set; }

       [Required(ErrorMessage = "This field is Required")]
        [Range(1, 10, ErrorMessage = "Must be between 1 and 10")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Range(1, 5, ErrorMessage = "Must be between 1 and 5")]
        public int RedactionId { get; set; }
    }
}
