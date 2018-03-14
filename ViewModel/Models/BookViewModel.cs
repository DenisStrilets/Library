using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViewModel.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(30, ErrorMessage = "Must be under 30 characters")]
        public string Name { get; set; }

        
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(15, ErrorMessage = "Must be under 15 characters")]
        public string Genre { get; set; }

        
        public string RedactionName { get; set; }


        [Required(ErrorMessage = "This field is Required")]
        [Range(1, 500, ErrorMessage = "Must be between 3 and 4")]
        public int Price { get; set; }

        public byte[] Image { get; set; }

        public string Image64 { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Range(1, 5, ErrorMessage = "Must be between 1 and 3")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Range(1, 5, ErrorMessage = "Must be between 1 and 5")]
        public int RedactionId { get; set; }

       
    }
}