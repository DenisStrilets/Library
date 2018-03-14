using BookingAppStore4.DALNew.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAppStore4.DALNew.Entities
{
    public class Redaction
    {

        [Key]
        public int RedactionId { get; set; }

        public string RedactionName { get; set; }

        public string Country { get; set; }


        public virtual ICollection<Book> Books {get;set;}

        public virtual ICollection <Gournal> Gournals { get; set; }

        public virtual ICollection<Brochure> Brochures { get; set; }

        public virtual ICollection<Publication> Publications { get; set; }
    }
}
