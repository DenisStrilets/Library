using AutoMapper;
using BookingAppStore4.DALNew.Repositories;
using BookingAppStore4.DALNew.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Xml;
using ViewModel.Enums;
using ViewModel.Models;
using BookingAppStore4.DALNew.Helpers;

namespace BookingAppStore4.DALNew.Services
{
    public class BookService
    {
        private BookRepository _bookRepository;

        private AuthorRepository _authorRepository;

        private RedactionRepository _redactionRepository;

        private ImageHelper _imageHelper;

        public BookService(string connection)
        {
            _bookRepository = new BookRepository(connection);
            _authorRepository = new AuthorRepository(connection);
            _redactionRepository = new RedactionRepository(connection);
            _imageHelper = new ImageHelper();
        }

        public IEnumerable<BookViewModel> GetAll()
        {
            List<Book> books = _bookRepository.GetAll().ToList();
            var result = Mapper.Map<List<Book>, List<BookViewModel>>(books);
            return result;
        }

        public BookViewModel Get(int? id)
        {
            Book book = _bookRepository.Get(id.Value);
            var result = Mapper.Map<Book, BookViewModel>(book);
            return result;
        }

        public void Create(BookViewModel bookViewModel, HttpPostedFileBase uploadImage)
        {
            var book = Mapper.Map<BookViewModel, Book>(bookViewModel);
            book.Type = LibraryType.Books;

            IEnumerable<Author> authors = _authorRepository.GetAll();
            book.AuthorName = authors.FirstOrDefault(x => x.AuthorId == book.AuthorId)?.AuthorName;

            IEnumerable<Redaction> redactions = _redactionRepository.GetAll();
            book.RedactionName = redactions.FirstOrDefault(x => x.RedactionId == book.RedactionId)?.RedactionName;

            byte[] imageData = _imageHelper.GetImage(uploadImage);

            book.Image = imageData;

            _bookRepository.Create(book);
        }

        public void Update(BookViewModel bookViewModel, HttpPostedFileBase uploadImage)
        {
            var book = Mapper.Map<BookViewModel,Book>(bookViewModel);

            IEnumerable<Book> books = _bookRepository.GetAll();

            int id = book.BookId;
            var bookFromDatabase = books.Where(u => u.BookId == id).FirstOrDefault();

            if (uploadImage == null)
            {
                book.Image = bookFromDatabase.Image;
            }

            IEnumerable<Author> authors = _authorRepository.GetAll();
            book.AuthorName = authors.FirstOrDefault(x => x.AuthorId == book.AuthorId)?.AuthorName;

            IEnumerable<Redaction> redactions = _redactionRepository.GetAll();
            book.RedactionName = redactions.FirstOrDefault(x => x.RedactionId == book.RedactionId)?.RedactionName;

            book.Type = LibraryType.Books;

            if (uploadImage != null)
            {
                byte[] imageData = _imageHelper.GetImage(uploadImage);

                book.Image = imageData;
            }
            _bookRepository.Update(book);
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }
    }
}
