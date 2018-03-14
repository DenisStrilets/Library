using BookingAppStore4.DALNew.Entities;
using BookingAppStore4.DALNew.Interfaces;
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
    public class GournalRepository : IGenericRepository<Gournal>
    {
        private LibraryContext _databaseLibraryContext;

        public GournalRepository(string connection)
        {
            _databaseLibraryContext = new LibraryContext(connection);
        }

        public IEnumerable<Gournal> GetAll()
        {
            var result = _databaseLibraryContext.Gournals;
            return result;
        }

        public Gournal Get(int id)
        {
            var result = _databaseLibraryContext.Gournals.Find(id);
            return result;
        }

        public void Create(Gournal gournal)
        {
            _databaseLibraryContext.Gournals.Add(gournal);
            _databaseLibraryContext.SaveChanges();
        }

        public void Update(Gournal gournal)
        {
            var gournalForUpdate = _databaseLibraryContext.Gournals.Where(x => x.GournalId == gournal.GournalId).FirstOrDefault();
            gournalForUpdate.Circulation = gournal.Circulation;
            gournalForUpdate.Genre = gournal.Genre;
            gournalForUpdate.Image = gournal.Image;
            gournalForUpdate.MainEditor = gournal.MainEditor;
            gournalForUpdate.Name = gournal.Name;
            gournalForUpdate.Price = gournal.Price;
            gournalForUpdate.Redaction = gournal.Redaction;
            gournalForUpdate.RedactionId = gournal.RedactionId;
            gournalForUpdate.RedactionName = gournal.RedactionName;
            gournalForUpdate.Type = gournal.Type;

            _databaseLibraryContext.SaveChanges();

        }

        public IEnumerable<Gournal> Find(Func<Gournal, Boolean> predicate)
        {
            var result = _databaseLibraryContext.Gournals.Where(predicate).ToList();
            return result;
        }

        public void Delete(int id)
        {
            Gournal gournal = _databaseLibraryContext.Gournals.Find(id);
            if (gournal != null)
            {
                _databaseLibraryContext.Gournals.Remove(gournal);
            }
            _databaseLibraryContext.SaveChanges();
        }

        public void Dispose()
        {
            _databaseLibraryContext.Dispose();
        }
    }
}
