using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Enums;

namespace BookingAppStore4.DALNew.Entities
{
   public class Gournal
    {
        public int GournalId { get; set; }
        
        public string Name { get; set; }
        
        public string Genre { get; set; }
        
        public string RedactionName { get; set; }
        
        public string MainEditor { get; set; }
        
        public int Price { get; set; }

        public LibraryType Type { get; set; }

        public byte[] Image { get; set; }

        public string Image64 { get { return Image != null ? Convert.ToBase64String(Image) : null; } }

        public int Circulation { get; set; }
        

        public int RedactionId { get; set; }

        [ForeignKey(nameof(RedactionId))]
       public virtual Redaction Redaction { get; set; }

    }
}
