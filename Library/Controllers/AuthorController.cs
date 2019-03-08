using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Models;

namespace Library.Controllers
{
    public class AuthorController : Controller
    {
        private LibraryEntities db = new LibraryEntities();
        [Route("authors")]
        public ActionResult Authors()
        {
            var modelquery = db.authors.Select(x => new Authors
            {
                Name = x.name,
                Surname = x.surname,
                Id = x.id

            }).ToList();
            return View("Authors", modelquery);
        }


        public ActionResult AddAuthors()
        {
            return View("AddAuthor");
        }

        [HttpPost]
        public ActionResult AddAuthors(author author)
        {
            var any = db.authors.SingleOrDefault(c => c.id == author.id && c.name == author.name && c.surname == author.surname);
            if (any != null)
            {
                ViewBag.ExistanceError = "This author already exists";
                return View("~/Views/Authors/AddAuthor.cshtml");
            }

            db.authors.Add(author);
            db.SaveChanges();
            var modelquery = db.authors.Select(x => new Authors
            {
                Name = x.name,
                Surname = x.surname,
                Id = x.id

            }).ToList();
            return View("~/Views/Authors/AuthorsView.cshtml", modelquery);
        }

        public ActionResult EditAuthors(int id)
        {
            var query = db.authors.SingleOrDefault(x => x.id == id);

            Authors author = new Authors()
            {
                Name = query.name,
                Surname = query.surname,
                Id = query.id
            };

            return View("~/Views/Authors/EditAuthor.cshtml", author);

        }

        [HttpPost]
        public ActionResult EditAuthors(author author)
        {
            var query = db.authors.SingleOrDefault(x => x.id == author.id);
            query.name = author.name;
            query.surname = author.surname;
            db.SaveChanges();

            var modelquery = db.authors.Select(x => new Authors
            {
                Name = x.name,
                Surname = x.surname,
                Id = x.id

            }).ToList();
            return View("~/Views/Authors/AuthorsView.cshtml", modelquery);
        }

    }
}