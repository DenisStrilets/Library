using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingAppStore4.WEB.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        public string Name { get; set; }

        public string AuthorName { get; set; }

        public string Genre { get; set; }

        public string RedactionName { get; set; }

        public int Price { get; set; }

        public int AuthorId { get; set; }
    }
}