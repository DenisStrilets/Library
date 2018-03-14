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
    public class GournalService
    {
        private GournalRepository _gournalRepository;

        private RedactionRepository _redactionRepository;

        private ImageHelper _imageHelper;

        public GournalService(string connection)
        {
            _gournalRepository = new GournalRepository(connection);
            _redactionRepository = new RedactionRepository(connection);
            _imageHelper = new ImageHelper();
        }

        public IEnumerable<GournalViewModel> GetAll()
        {
            List<Gournal> gournals = _gournalRepository.GetAll().ToList();
            var result = Mapper.Map<List<Gournal>, List<GournalViewModel>>(gournals);
            return result;
        }

        public GournalViewModel Get(int? id)
        {
            Gournal gournal = _gournalRepository.Get(id.Value);
            var result = Mapper.Map<Gournal, GournalViewModel>(gournal);
            return result;
        }

        public void Create(GournalViewModel gournalViewModel, HttpPostedFileBase uploadImage)
        {
            var gournal = Mapper.Map<GournalViewModel, Gournal>(gournalViewModel);
            gournal.Type = LibraryType.Gournals;

            IEnumerable<Redaction> redactions = _redactionRepository.GetAll();
            gournal.RedactionName = redactions.FirstOrDefault(x => x.RedactionId == gournal.RedactionId)?.RedactionName;

            byte[] imageData = _imageHelper.GetImage(uploadImage);

            gournal.Image = imageData;

            _gournalRepository.Create(gournal);
        }

        public void Update(GournalViewModel gournalViewModel, HttpPostedFileBase uploadImage)
        {
            var gournal = Mapper.Map<GournalViewModel, Gournal>(gournalViewModel);

            IEnumerable<Gournal> gournals = _gournalRepository.GetAll();

            int id = gournal.GournalId;
            var gournalFromDatabase = gournals.Where(u => u.GournalId == id).FirstOrDefault();

            if (uploadImage == null)
            {
                gournal.Image = gournalFromDatabase.Image;
            }

            IEnumerable<Redaction> redactions = _redactionRepository.GetAll();
            gournal.RedactionName = gournals.FirstOrDefault(x => x.RedactionId == gournal.RedactionId)?.RedactionName;

            gournal.Type = LibraryType.Gournals;

            if (uploadImage != null)
            {
                byte[] imageData = _imageHelper.GetImage(uploadImage);

                gournal.Image = imageData;
            }

            _gournalRepository.Update(gournal);
        }

        public void Delete(int id)
        {
            _gournalRepository.Delete(id);
        }
    }
}
