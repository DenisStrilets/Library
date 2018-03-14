using AutoMapper;
using BookingAppStore4.DALNew.Services;
using BookingAppStore4.DALNew.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Models;

namespace BookingAppStore4.WEB.Controllers
{
    public class AuthorController : Controller
    {
        private string _connectionString;
        private AuthorService _authorService;
        public AuthorController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString;
            _authorService = new AuthorService(_connectionString);
        }

        public JsonResult GetAll()
        {
            List<AuthorViewModel> authorViews = _authorService.GetAll().ToList();
            return Json(authorViews, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                List<AuthorViewModel> authorViews = _authorService.GetAll().ToList();
                return View(authorViews);
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
        public ActionResult Create(AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                _authorService.Create(author);
                return RedirectToAction("Index");
            }
            return View(author);
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
                AuthorViewModel author = _authorService.Get(id);
                if (author != null)
                {
                    return View("Edit", author);
                }
                return HttpNotFound();
            }
            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost]
        public ActionResult Edit(AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                _authorService.Update(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (User.IsInRole("admin"))
            {
                AuthorViewModel author = _authorService.Get(id);
                if (author == null)
                {
                    return HttpNotFound();
                }
                return View("Delete", author);
            }
            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _authorService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}