using Data.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Library.Controllers.Api
{
    public class PostedJson
    {
        public int book_id { get; set; }
        public int auuthor_id { get; set; }

    }
    public class BookAuthorController : ApiController
    {
        private LibraryEntities db = new LibraryEntities();

        // GET: api/BookAuthor
        public IQueryable<authors_books> Getauthors_books()
        {
            return db.authors_books;
        }
        // GET: api/BookAuthor/5
        //[ResponseType(typeof(authors_books))]
        //public JsonResult Getauthors_books(PostedJson json)
        //{    

        //    //model.authors = db.authors_books.Where(x => x.book_id == id && x.author.id != x.author_id).Select(x => new SelectListItem()
        //    //{
        //    //    Text = x.author.name,
        //    //    Value = x.author.id.ToString()
        //    //});
        //    //return Json(json.auuthor_id, JsonRequestBehavior.AllowGet);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool authors_booksExists(int id)
        {
            return db.authors_books.Count(e => e.id == id) > 0;
        }
    }
}