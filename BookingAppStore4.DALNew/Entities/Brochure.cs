using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Enums;

namespace BookingAppStore4.DALNew.Entities
{
    public class Brochure
    {
        public int BrochureId { get; set; }
        
        public string Name { get; set; }
        
        public string RedactionName { get; set; }

        public LibraryType Type { get; set; }

        public int Price { get; set; }

        public int MinOrdering { get; set; }
        
        public int RedactionId { get; set; }

        public string Theme { get; set; }

        public byte[] Image { get; set; }

        public string Image64 { get { return Image != null ? Convert.ToBase64String(Image) : null; } }

        [ForeignKey(nameof(RedactionId))]
       public virtual Redaction Redaction { get; set; }
    }
}
