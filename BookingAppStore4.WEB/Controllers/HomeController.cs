using BookingAppStore4.DALNew.Services;
using BookingAppStore4.DALNew.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using ViewModel.Models;

namespace BookingAppStore4.WEB.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString;
        private BookService _bookService;
        public HomeController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString;
            _bookService = new BookService(_connectionString);
        }

        public JsonResult GetAll()
        {
            List<BookViewModel> bookViews = _bookService.GetAll().ToList();
            JsonResult result = Json(bookViews, JsonRequestBehavior.AllowGet);
            result.MaxJsonLength = int.MaxValue;

            return result;
        }

        
        public ActionResult Index()
        {         
            List<BookViewModel> bookViews = _bookService.GetAll().ToList();

            if (User.IsInRole("admin"))
            {
                return View("IndexForAdmin", bookViews);
            }
            if (User.IsInRole("user"))
            {
                return View("IndexForUser", bookViews);
            }
            return View("IndexForUnregister", bookViews);

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
        public ActionResult Create(BookViewModel book, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                _bookService.Create(book, uploadImage);
                return RedirectToAction("Index");

            }
            return View(book);
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
            BookViewModel book = _bookService.Get(id);
            if (book != null)
            {
                return View("Edit", book);
            }
            return HttpNotFound();
            }
            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel book, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {             
                    _bookService.Update(book, uploadImage);
                    return RedirectToAction("Index");   
            }
            return View(book);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (User.IsInRole("admin"))
            { 
            BookViewModel book = _bookService.Get(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View("Delete", book);
            }
            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _bookService.Delete(id);
            return RedirectToAction("Index");
        }
       
    }
}