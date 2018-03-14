using AutoMapper;
using BookingAppStore4.DALNew.Helpers;
using BookingAppStore4.DALNew.Entities;
using BookingAppStore4.DALNew.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ViewModel.Enums;
using ViewModel.Models;

namespace BookingAppStore4.DALNew.Services
{
    public class PublicationService
    {
        private PublicationRepository _publicationRepository;

        private AuthorRepository _authorRepository;

        private RedactionRepository _redactionRepository;

        private ImageHelper _imageHelper;

        public PublicationService(string connection)
        {
            _publicationRepository = new PublicationRepository(connection);

            _authorRepository = new AuthorRepository(connection);

            _redactionRepository = new RedactionRepository(connection);

            _imageHelper = new ImageHelper();

        }

        public IEnumerable<PublicationViewModel> GetAll()
        {
            List<Publication> publications = _publicationRepository.GetAll().ToList();
            var result = Mapper.Map<List<Publication>, List<PublicationViewModel>>(publications);
            return result;
        }

        public PublicationViewModel Get(int? id)
        {
            Publication publication = _publicationRepository.Get(id.Value);
            var result = Mapper.Map<Publication, PublicationViewModel>(publication);
            return result;
        }

        public void Create(PublicationViewModel publicationViewModel, HttpPostedFileBase uploadImage)
        {
            var publication = Mapper.Map<PublicationViewModel, Publication>(publicationViewModel);
            publication.Type = LibraryType.Publications;

            IEnumerable<Author> authors = _authorRepository.GetAll();
            publication.AuthorName = authors.FirstOrDefault(x => x.AuthorId == publication.AuthorId)?.AuthorName;

            IEnumerable<Redaction> redactions = _redactionRepository.GetAll();
            publication.RedactionName = redactions.FirstOrDefault(x => x.RedactionId == publication.RedactionId)?.RedactionName;

            byte[] imageData = _imageHelper.GetImage(uploadImage);

            publication.Image = imageData;

            _publicationRepository.Create(publication);

        }

        public void Update(PublicationViewModel publicationViewModel, HttpPostedFileBase uploadImage)
        {
            var publication = Mapper.Map<PublicationViewModel, Publication>(publicationViewModel);

            IEnumerable<Publication> publications = _publicationRepository.GetAll();

            int id = publication.PublicationId;
            var publicationFromDatabase = publications.Where(u => u.PublicationId == id).FirstOrDefault();

            if (uploadImage == null)
            {
                publication.Image = publicationFromDatabase.Image;
            }

            IEnumerable<Author> authors = _authorRepository.GetAll();
            publication.AuthorName = authors.FirstOrDefault(x => x.AuthorId == publication.AuthorId)?.AuthorName;

            IEnumerable<Redaction> redactions = _redactionRepository.GetAll();
            publication.RedactionName = redactions.FirstOrDefault(x => x.RedactionId == publication.RedactionId)?.RedactionName;

            publication.Type = LibraryType.Publications;

            if (uploadImage != null)
            {
                byte[] imageData = _imageHelper.GetImage(uploadImage);

                publication.Image = imageData;
            }
            _publicationRepository.Update(publication);
        }

        public void Delete(int id)
        {
            _publicationRepository.Delete(id);
        }
    }
}
