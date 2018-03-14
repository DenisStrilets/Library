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
    public class BrochureController : Controller
    {
        private string _connectionString;
        private BrochureService _brochureService;
        public BrochureController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString;
            _brochureService = new BrochureService(_connectionString);
        }

        public JsonResult GetAll()
        {
            List<BrochureViewModel> brochureViews = _brochureService.GetAll().ToList();
            JsonResult result = Json(brochureViews, JsonRequestBehavior.AllowGet);
            result.MaxJsonLength = int.MaxValue;

            return result;
        }

        public ActionResult Index()
        {          
            List<BrochureViewModel> brochureViews = _brochureService.GetAll().ToList();

            if (User.IsInRole("admin"))
            { 
            return View("IndexForAdmin",brochureViews);
            }
            if (User.IsInRole("user"))
            {
                return View("IndexForUser", brochureViews);
            }
            return View("IndexForUnregister", brochureViews);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (User.IsInRole("admin"))
            { 
                return View();
            }
            return RedirectToAction("LogIn","Account");
        }

        [HttpPost]
        public ActionResult Create(BrochureViewModel brochure, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                _brochureService.Create(brochure, uploadImage);
                return RedirectToAction("Index");
            }
            return View(brochure);
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
            BrochureViewModel brochure = _brochureService.Get(id);
            if (brochure != null)
            {
                return View("Edit", brochure);
            }
            return HttpNotFound();
            }
            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost]
        public ActionResult Edit(BrochureViewModel brochure, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                _brochureService.Update(brochure, uploadImage);
                return RedirectToAction("Index");
            }
            return View(brochure);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (User.IsInRole("admin"))
            {
                BrochureViewModel brochure = _brochureService.Get(id);
                if (brochure == null)
                {
                    return HttpNotFound();
                }
                return View("Delete", brochure);
            }
            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _brochureService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}