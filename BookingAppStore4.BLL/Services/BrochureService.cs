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
    public class BrochureService
    {
        private BrochureRepository _brochureRepository;

        private RedactionRepository _redactionRepository;

        private ImageHelper _imageHelper;

        public BrochureService(string connection)
        {
            _brochureRepository = new BrochureRepository(connection);
            _redactionRepository = new RedactionRepository(connection);
            _imageHelper = new ImageHelper();
        }

        public IEnumerable<BrochureViewModel> GetAll()
        {
            List<Brochure> brochures = _brochureRepository.GetAll().ToList();
            var result = Mapper.Map<List<Brochure>, List<BrochureViewModel>>(brochures);
            return result;
        }

        public BrochureViewModel Get(int? id)
        {
            Brochure brochure = _brochureRepository.Get(id.Value);
            var result = Mapper.Map<Brochure, BrochureViewModel>(brochure);
            return result;
        }

        public void Create(BrochureViewModel brochureViewModel, HttpPostedFileBase uploadImage)
        {
            var brochure = Mapper.Map<BrochureViewModel, Brochure>(brochureViewModel);
            brochure.Type = LibraryType.Brochures;

            IEnumerable<Redaction> redactions = _redactionRepository.GetAll();
            brochure.RedactionName = redactions.FirstOrDefault(x => x.RedactionId == brochure.RedactionId)?.RedactionName;

            byte[] imageData = _imageHelper.GetImage(uploadImage);

            brochure.Image = imageData;

            _brochureRepository.Create(brochure);
        }

        public void Update(BrochureViewModel brochureViewModel, HttpPostedFileBase uploadImage)
        {
            var brochure = Mapper.Map<BrochureViewModel, Brochure>(brochureViewModel);

            IEnumerable<Brochure> brochures = _brochureRepository.GetAll();

            int id = brochure.BrochureId;
            var brochureFromDatabase = brochures.Where(u => u.BrochureId == id).FirstOrDefault();

            if (uploadImage == null)
            {
                brochure.Image = brochureFromDatabase.Image;
            }

            IEnumerable<Redaction> redactions = _redactionRepository.GetAll();
            brochure.RedactionName = redactions.FirstOrDefault(x => x.RedactionId == brochure.RedactionId)?.RedactionName;

            brochure.Type = LibraryType.Brochures;

            if (uploadImage != null)
            {
                byte[] imageData = _imageHelper.GetImage(uploadImage);

                brochure.Image = imageData;
            }

            _brochureRepository.Update(brochure);
        }

        public void Delete(int id)
        {
            _brochureRepository.Delete(id);
        }
    }
}
