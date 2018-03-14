using BookingAppStore4.DALNew.Interfaces;
using BookingAppStore4.DALNew.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;

namespace BookingAppStore4.DALNew.Repositories
{
    public class BookRepository : IGenericRepository<Book>
    {
        private LibraryContext _databaseLibraryContext;

        public BookRepository(string connection)
        {
            _databaseLibraryContext = new LibraryContext(connection);
        }

        public void Create(Book book)
        {
            _databaseLibraryContext.Books.Add(book);
            _databaseLibraryContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _databaseLibraryContext.Books.Remove(_databaseLibraryContext.Books.Find(id));
            _databaseLibraryContext.SaveChanges();
        }

        public void Dispose()
        {
            _databaseLibraryContext.Dispose();
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            var result = _databaseLibraryContext.Books.Where(predicate).ToList();
            return result;
        }

        public Book Get(int id)
        {
            var result = _databaseLibraryContext.Books.Find(id);
            return result;
        }

        public IEnumerable<Book> GetAll()
        {
            var result = _databaseLibraryContext.Books;
            return result;
        }

        public void Update(Book book)
        {
            var bookForUpdate = _databaseLibraryContext.Books.Where(x => x.BookId == book.BookId).FirstOrDefault();
            bookForUpdate.Author = book.Author;
            bookForUpdate.AuthorName = book.AuthorName;
            bookForUpdate.AuthorId = book.AuthorId;
            bookForUpdate.Genre = book.Genre;
            bookForUpdate.Image = book.Image;
            bookForUpdate.Name = book.Name;
            bookForUpdate.Price = book.Price;
            bookForUpdate.Redaction = book.Redaction;
            bookForUpdate.RedactionId = book.RedactionId;
            bookForUpdate.RedactionName = book.RedactionName;
            bookForUpdate.Type = book.Type;

            _databaseLibraryContext.SaveChanges();
        }


    }
}