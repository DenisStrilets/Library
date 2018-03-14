using BookingAppStore4.DALNew.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Enums;

namespace BookingAppStore4.DALNew.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        public string Name { get; set; }

        public string AuthorName { get; set; }

        public string Genre { get; set; }

        public string RedactionName { get; set; }

        public int Price { get; set; }

        public int AuthorId { get; set; }

        public int RedactionId { get; set; }

        public byte[] Image { get; set; }

        public string Image64 { get { return Image != null ? Convert.ToBase64String(Image) : null; } }

        public LibraryType Type { get; set; }

        [ForeignKey(nameof(AuthorId))]
         public virtual Author Author { get; set; }

        [ForeignKey(nameof(RedactionId))]
        public virtual Redaction Redaction { get; set; }
    }
}
