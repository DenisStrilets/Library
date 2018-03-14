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
    public class RedactionController : Controller
    {
        private string _connectionString;
        private RedactionService _redactionService;
        public RedactionController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString;
            _redactionService = new RedactionService(_connectionString);
        }

        public JsonResult GetAll()
        {
            List<RedactionViewModel> redactionViews = _redactionService.GetAll().ToList();
            return Json(redactionViews, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                List<RedactionViewModel> redactionViews = _redactionService.GetAll().ToList();
                return View(redactionViews);
            }
            return RedirectToAction("LogIn", "Account");
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
        public ActionResult Create(RedactionViewModel redaction)
        {
            if (ModelState.IsValid)
            {
                _redactionService.Create(redaction);
                return RedirectToAction("Index");
            }
            return View(redaction);
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
                RedactionViewModel redaction = _redactionService.Get(id);
                if (redaction != null)
                {
                    return View("Edit", redaction);
                }
                return HttpNotFound();
            }
            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost]
        public ActionResult Edit(RedactionViewModel redaction)
        {
            if (ModelState.IsValid)
            {
                _redactionService.Update(redaction);
                return RedirectToAction("Index");
            }
            return View(redaction);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (User.IsInRole("admin"))
            {
                RedactionViewModel redaction = _redactionService.Get(id);
                if (redaction == null)
                {
                    return HttpNotFound();
                }
                return View("Delete", redaction);
            }
            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _redactionService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}