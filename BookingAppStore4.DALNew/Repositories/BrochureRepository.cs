using BookingAppStore4.DALNew.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookingAppStore4.DALNew.Repositories
{
    public class BrochureRepository
    {
        private LibraryContext _databaseLibraryContext;

        public BrochureRepository(string connection)
        {
            _databaseLibraryContext = new LibraryContext(connection);
        }

        public IEnumerable<Brochure> GetAll()
        {
            var result = _databaseLibraryContext.Brochures;
            return result;
        }

        public Brochure Get(int id)
        {
            var result = _databaseLibraryContext.Brochures.Find(id);
            return result;
        }

        public void Create(Brochure brochure)
        {
            _databaseLibraryContext.Brochures.Add(brochure);
            _databaseLibraryContext.SaveChanges();
        }

        public void Update(Brochure brochure)
        {
            var brochureForUpdate = _databaseLibraryContext.Brochures.Where(x => x.BrochureId == brochure.BrochureId).FirstOrDefault();
            brochureForUpdate.Image = brochure.Image;
            brochureForUpdate.MinOrdering = brochure.MinOrdering;
            brochureForUpdate.Name = brochure.Name;
            brochureForUpdate.Price = brochure.Price;
            brochureForUpdate.Redaction = brochure.Redaction;
            brochureForUpdate.RedactionId = brochure.RedactionId;
            brochureForUpdate.RedactionName = brochure.RedactionName;
            brochureForUpdate.Theme = brochure.Theme;
            brochureForUpdate.Type = brochure.Type;

            _databaseLibraryContext.SaveChanges();
        }

        public IEnumerable<Brochure> Find(Func<Brochure, Boolean> predicate)
        {
            var result = _databaseLibraryContext.Brochures.Where(predicate).ToList();
            return result;
        }

        public void Delete(int id)
        {
            Brochure brochure = _databaseLibraryContext.Brochures.Find(id);
            if (brochure != null)
            {
                _databaseLibraryContext.Brochures.Remove(brochure);
            }
            _databaseLibraryContext.SaveChanges();
        }

        public void Dispose()
        {
            _databaseLibraryContext.Dispose();
        }
    }
}
