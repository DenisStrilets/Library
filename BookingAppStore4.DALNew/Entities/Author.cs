using BookingAppStore4.DALNew.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookingAppStore4.DALNew.Entities
{
   public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string Country { get; set; }

        public int YearOfBirth { get; set; }


        public virtual ICollection<Book> Books { get; set; }

        public virtual ICollection<Publication> Publications { get; set; }
    }
}
