using BookingAppStore4.DALNew.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 
using ViewModel.Models;

namespace BookingAppStore4.WEB.Controllers
{
    public class LibraryController : Controller
    {
        private string _connectionString;
        private LibraryService _libraryService;

        public LibraryController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString;
            _libraryService = new LibraryService(_connectionString);         
        }

        public JsonResult GetAll()
        {
            List<LibraryViewModel> libraryViews = _libraryService.GetLibrary().ToList();
            JsonResult result =Json(libraryViews, JsonRequestBehavior.AllowGet);
            result.MaxJsonLength = int.MaxValue;

            return result;
        }

        public ActionResult Index()
        {
            List<LibraryViewModel> libraryViews = _libraryService.GetLibrary().ToList();
            return View(libraryViews);
        }
    }
}