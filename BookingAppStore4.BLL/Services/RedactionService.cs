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
    public class RedactionService
    {
        private RedactionRepository _redactionRepository;

        public RedactionService(string connection)
        {
            _redactionRepository = new RedactionRepository(connection);
        }

        public IEnumerable<RedactionViewModel> GetAll()
        {
            List<Redaction> redactions = _redactionRepository.GetAll().ToList();
            var result = Mapper.Map<List<Redaction>, List<RedactionViewModel>>(redactions);
            return result;
        }

        public RedactionViewModel Get(int? id)
        {
            var redaction = _redactionRepository.Get(id.Value);
            return Mapper.Map<Redaction, RedactionViewModel>(redaction);
        }

        public void Create(RedactionViewModel redactionViewModel)
        {
            var redaction = Mapper.Map<RedactionViewModel, Redaction>(redactionViewModel);
            _redactionRepository.Create(redaction);
        }

        public void Update(RedactionViewModel redactionViewModel)
        {
            var redaction = Mapper.Map<RedactionViewModel, Redaction>(redactionViewModel);
            _redactionRepository.Update(redaction);
        }

        public void Delete(int id)
        {
            _redactionRepository.Delete(id);
        }
    }
}
