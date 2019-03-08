using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Data.Entity;
using Model.Models;

namespace Library.Controllers
{
    public class LoginController : Controller
    {

        private LibraryEntities db = new LibraryEntities();
        // GET: Login
        [System.Web.Mvc.Route("Login")]
        public ActionResult Login()
        {
            //BookAuthorConnector a = new BookAuthorConnector();
            return View();
        }
        [System.Web.Mvc.Route("Login")]
        [System.Web.Mvc.HttpPost]
        public ActionResult Login(Users user)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var userdata = db.users.SingleOrDefault(c => c.username == user.Username && c.password == user.Password);
            if (userdata == null)
            {
                ViewBag.LoginError = "Wrong username/password";
                return View("Login");
            }

            //Create Session
            var privilege = db.privileges.SingleOrDefault(c => c.id == userdata.id);
            Session["Current_User"] = new SessionConstructor()
            {
                Privilege = privilege.privilege1,
                Id = userdata.id
            };

            return RedirectToAction("BookAuthorSelect", "Connection");

        }
    }
}