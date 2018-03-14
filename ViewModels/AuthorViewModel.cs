using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingAppStore4.WEB.Models
{
    public class AuthorViewModel
    {
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string Country { get; set; }

        public int YearOfBirth { get; set; }
    }
}