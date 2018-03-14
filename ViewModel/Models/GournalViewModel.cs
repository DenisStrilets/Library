using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Models
{
    public class GournalViewModel
    {
        public int GournalId { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(30, ErrorMessage = "Must be under 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(15, ErrorMessage = "Must be under 15 characters")]
        public string Genre { get; set; }

         
        public string RedactionName { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [StringLength(15, ErrorMessage = "Must be under 15 characters")]
        public string MainEditor { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Range(1, 500, ErrorMessage = "Must be between 1 and 500")]
        public int Price { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Range(1, 500, ErrorMessage = "Must be between 1 and 500")]
        public int Circulation { get; set; }

        public byte[] Image { get; set; }

        public string Image64 { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Range(1, 5, ErrorMessage = "Must be between 1 and 5")]
        public int RedactionId { get; set; }
    }
}
