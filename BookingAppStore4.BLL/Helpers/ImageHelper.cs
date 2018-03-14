using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookingAppStore4.DALNew.Helpers
{
    public class ImageHelper
    {
        public byte[] GetImage(HttpPostedFileBase uploadImage)
        {
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(uploadImage.InputStream))
            {
                imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
            }
            return imageData;
        }
    }
}
