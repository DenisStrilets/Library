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
    public class PublicationController : Controller
    {
        private string _connectionString;
        private PublicationService _publicationService;
        public PublicationController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString;
            _publicationService = new PublicationService(_connectionString);
        }

        public JsonResult GetAll()
        {
            List<PublicationViewModel> publicationViews = _publicationService.GetAll().ToList();
            JsonResult result = Json(publicationViews, JsonRequestBehavior.AllowGet);
            result.MaxJsonLength = int.MaxValue;

            return result;
        }

        public ActionResult Index()
        {
            List<PublicationViewModel> publicationViews = _publicationService.GetAll().ToList();

            if (User.IsInRole("admin"))
            {
                return View("IndexForAdmin", publicationViews);
            }
            if (User.IsInRole("user"))
            {
                return View("IndexForUser", publicationViews);
            }
            return View("IndexForUnregister", publicationViews);
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
        public ActionResult Create(PublicationViewModel publication, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            { 
            _publicationService.Create(publication,uploadImage);
            return RedirectToAction("Index");
            }
            return View(publication);

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
            PublicationViewModel publication = _publicationService.Get(id);
            if (publication != null)
            {
                return View("Edit", publication);
            }
            return HttpNotFound();
            }
            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost]
        public ActionResult Edit(PublicationViewModel publication, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            { 
            _publicationService.Update(publication, uploadImage);
            return RedirectToAction("Index");
            }
            return View(publication);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (User.IsInRole("admin"))
            { 
            PublicationViewModel publication = _publicationService.Get(id);
            if (publication == null)
            {
                return HttpNotFound();
            }
            return View("Delete", publication);
            }
            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _publicationService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}