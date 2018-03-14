using BookingAppStore4.DALNew.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Models;

namespace BookingAppStore4.WEB.Controllers
{
    public class GournalController : Controller
    {
        private string _connectionString;
        private GournalService _gournalService;
        public GournalController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString;
            _gournalService = new GournalService(_connectionString);
        }

        public JsonResult GetAll()
        {
            List<GournalViewModel> gournalViews = _gournalService.GetAll().ToList();
            JsonResult result = Json(gournalViews, JsonRequestBehavior.AllowGet);
            result.MaxJsonLength = int.MaxValue;

            return result;
        }

        public ActionResult Index()
        {
            List<GournalViewModel> gournalViews = _gournalService.GetAll().ToList();

            if (User.IsInRole("admin"))
            {
                return View("IndexForAdmin", gournalViews);
            }
            if (User.IsInRole("user"))
            {
                return View("IndexForUser", gournalViews);
            }
            return View("IndexForUnregister", gournalViews);

        }

        [HttpGet]
        public ActionResult Create()
        {
            if (User.IsInRole("admin"))
            { 
            return View();
            }
            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost]
        public ActionResult Create(GournalViewModel gournal, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            { 
            _gournalService.Create(gournal, uploadImage);
            return RedirectToAction("Index");
            }
            return View(gournal);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (User.IsInRole("admin"))
            { 
            if (id == null)
            {
                return HttpNotFound();
            }
            GournalViewModel gournal = _gournalService.Get(id);
            if (gournal != null)
            {
                return View("Edit", gournal);
            }
            return HttpNotFound();
            }
            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost]
        public ActionResult Edit(GournalViewModel gournal, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            { 
            _gournalService.Update(gournal, uploadImage);
            return RedirectToAction("Index");
            }
            return View(gournal);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (User.IsInRole("admin"))
            { 
            GournalViewModel gournal = _gournalService.Get(id);
            if (gournal == null)
            {
                return HttpNotFound();
            }
            return View("Delete", gournal);
            }
            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _gournalService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}