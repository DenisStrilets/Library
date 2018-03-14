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
   public class AuthorService
    {
        private AuthorRepository _authorRepository;
        
        public AuthorService(string connection)
        {
            _authorRepository = new AuthorRepository( connection);
        }

        public IEnumerable<AuthorViewModel> GetAll()
        {          
           List<Author> authors = _authorRepository.GetAll().ToList();
            var result = Mapper.Map<List<Author>, List<AuthorViewModel>>(authors);
            return result;
        }

        public AuthorViewModel Get(int ?id)
        {
            Author author = _authorRepository.Get(id.Value);
            var result = Mapper.Map<Author, AuthorViewModel>(author);
            return result;
        }

        public void Create(AuthorViewModel authorViewModel)
        {
          
            var author  = Mapper.Map<AuthorViewModel, Author>(authorViewModel);
            _authorRepository.Create(author);            
        }

        public void Update(AuthorViewModel authorViewModel)
        {
            var author = Mapper.Map<AuthorViewModel, Author>(authorViewModel);
            _authorRepository.Update(author);
        }

        public void Delete(int id)
        {
            _authorRepository.Delete(id);           
        }
    }
}
