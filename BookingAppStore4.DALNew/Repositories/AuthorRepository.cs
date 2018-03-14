using BookingAppStore4.DALNew.Interfaces;
using BookingAppStore4.DALNew.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace BookingAppStore4.DALNew.Repositories
{
    public class AuthorRepository : IGenericRepository<Author>
    {
        private LibraryContext _databaseLibraryContext;

        public AuthorRepository(string connection)
        {
            _databaseLibraryContext = new LibraryContext(connection);
        }

        public void Create(Author author)
        {
            _databaseLibraryContext.Authors.Add(author);
        }

        public void Delete(int id)
        {
            Author author = _databaseLibraryContext.Authors.Find(id);
            if (author != null)
            {
                _databaseLibraryContext.Authors.Remove(author);
                _databaseLibraryContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            _databaseLibraryContext.Dispose();
        }

        public IEnumerable<Author> Find(Func<Author, bool> predicate)
        {
            var result = _databaseLibraryContext.Authors.Where(predicate).ToList();
            return result;
        }

        public Author Get(int id)
        {
            var result = _databaseLibraryContext.Authors.Find(id);
            return result;
        }

        public IEnumerable<Author> GetAll()
        {
            var result = _databaseLibraryContext.Authors;
            return result;
        }

        public void Update(Author author)
        {
            _databaseLibraryContext.Entry(author).State = EntityState.Modified;
            _databaseLibraryContext.SaveChanges();
        }

    }
}
