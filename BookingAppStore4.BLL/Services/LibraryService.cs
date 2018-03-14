using AutoMapper;
using BookingAppStore4.DALNew.Entities;
using BookingAppStore4.DALNew.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Models;

namespace BookingAppStore4.DALNew.Services
{
    public class LibraryService
    {
        private BookRepository _bookRepository;
        private BrochureRepository _brochureRepository;
        private GournalRepository _gournalRepository;
        private PublicationRepository _publicationRepository;

        public LibraryService(string connection)
        {
            _bookRepository = new BookRepository(connection);
            _brochureRepository = new BrochureRepository(connection);
            _gournalRepository = new GournalRepository(connection);
            _publicationRepository = new PublicationRepository(connection);
        }

        public IEnumerable<LibraryViewModel> GetLibrary()
        {

            List<Book> books = _bookRepository.GetAll().ToList();
            var viewBooks=Mapper.Map<List<Book>, List<LibraryViewModel>>(books);
            
            List<Brochure> brochures = _brochureRepository.GetAll().ToList();
            var viewBrochures = Mapper.Map<List<Brochure>, List<LibraryViewModel>>(brochures);

            List<Gournal> gournals = _gournalRepository.GetAll().ToList();
           var viewGournals = Mapper.Map<List<Gournal>, List<LibraryViewModel>>(gournals);

            List<Publication> publications = _publicationRepository.GetAll().ToList();
            var viewPublications = Mapper.Map<List<Publication>, List<LibraryViewModel>>(publications);

            List<LibraryViewModel> library = new List<LibraryViewModel>();

            library.AddRange(viewBooks);
            library.AddRange(viewBrochures);
            library.AddRange(viewGournals);
            library.AddRange(viewPublications);

            return library;
        }        
    }
}
