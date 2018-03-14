using BookingAppStore4.DALNew.Interfaces;
using BookingAppStore4.DALNew.Entities;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAppStore4.DALNew.Repositories
{
    public class RedactionRepository : IGenericRepository<Redaction>
    {
        private LibraryContext _databaseLibraryContext;

        public RedactionRepository(string connection)
        {
            _databaseLibraryContext = new LibraryContext(connection);
        }

        public void Create(Redaction redaction)
        {
            _databaseLibraryContext.Redactions.Add(redaction);
            _databaseLibraryContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Redaction redaction = _databaseLibraryContext.Redactions.Find(id);
            if (redaction != null)
            {
                _databaseLibraryContext.Redactions.Remove(redaction);
                _databaseLibraryContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            _databaseLibraryContext.Dispose();
        }

        public IEnumerable<Redaction> Find(Func<Redaction, bool> predicate)
        {
            var result = _databaseLibraryContext.Redactions.Where(predicate).ToList();
            return result;
        }

        public Redaction Get(int id)
        {
            var result = _databaseLibraryContext.Redactions.Find(id);
            return result;
        }

        public IEnumerable<Redaction> GetAll()
        {
            var result = _databaseLibraryContext.Redactions;
            return result;
        }

        public void Update(Redaction redaction)
        {
            _databaseLibraryContext.Entry(redaction).State = EntityState.Modified;
            _databaseLibraryContext.SaveChanges();
        }

    }
}
