using BookingAppStore4.DALNew.Interfaces;
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
    public class PublicationRepository : IGenericRepository<Publication>
    {
        private LibraryContext _databaseLibraryContext;

        public PublicationRepository(string connection)
        {
            _databaseLibraryContext = new LibraryContext(connection);
        }

        public IEnumerable<Publication> GetAll()
        {
            var result = _databaseLibraryContext.Publications;
            return result;
        }

        public Publication Get(int id)
        {
            var result = _databaseLibraryContext.Publications.Find(id);
            return result;
        }

        public void Create(Publication publication)
        {
            _databaseLibraryContext.Publications.Add(publication);
            _databaseLibraryContext.SaveChanges();
        }

        public void Update(Publication publication)
        {
            var publicationForUpdate = _databaseLibraryContext.Publications.Where(x => x.PublicationId == publication.PublicationId).FirstOrDefault();
            publicationForUpdate.Author = publication.Author;
            publicationForUpdate.AuthorName = publication.AuthorName;
            publicationForUpdate.AuthorId = publication.AuthorId;
            publicationForUpdate.Image = publication.Image;
            publicationForUpdate.Name = publication.Name;
            publicationForUpdate.Pages = publication.Price;
            publicationForUpdate.Redaction = publication.Redaction;
            publicationForUpdate.RedactionName = publication.RedactionName;
            publicationForUpdate.Title = publication.Title;
            publicationForUpdate.Tome = publication.Tome;
            publicationForUpdate.Type = publication.Type;

            _databaseLibraryContext.SaveChanges();
        }

        public IEnumerable<Publication> Find(Func<Publication, Boolean> predicate)
        {
            var result = _databaseLibraryContext.Publications.Where(predicate).ToList();
            return result;
        }

        public void Delete(int id)
        {
            Publication publication = _databaseLibraryContext.Publications.Find(id);
            if (publication != null)
            {
                _databaseLibraryContext.Publications.Remove(publication);
            }
            _databaseLibraryContext.SaveChanges();
        }

        public void Dispose()
        {
            _databaseLibraryContext.Dispose();
        }
    }
}
