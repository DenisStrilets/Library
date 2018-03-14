using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Enums;

namespace BookingAppStore4.DALNew.Entities
{
    public class Publication
    {
        public int PublicationId { get; set; }
        
        public string AuthorName { get; set; }
    
        public string Name { get; set; }
         
        public string Title { get; set; }
         
        public string RedactionName { get; set; }
        
        public int Tome { get; set; }
      
        public int Pages { get; set; }
         
        public int Price { get; set; }

        public LibraryType Type { get; set; }

        public byte[] Image { get; set; }

        public string Image64 { get { return Image != null ? Convert.ToBase64String(Image) : null; } }

        public int AuthorId { get; set; }
         
        public int RedactionId { get; set; }

        [ForeignKey(nameof(AuthorId))]
       public virtual Author Author { get; set; }

        [ForeignKey(nameof(RedactionId))]
       public virtual Redaction Redaction { get; set; }

    }
}
