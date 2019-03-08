using AutoMapper;
using Data.Entity;
using Model.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [System.Web.Mvc.Route("Registration")]
        public ActionResult Registration()
        {
            return View();
        }
      
        private LibraryEntities db = new LibraryEntities();

        [System.Web.Mvc.Route("Registration")]
        [System.Web.Mvc.HttpPost]
        public ActionResult Registration(Users UserModel)
        {
            users_privileges userprev = new users_privileges();
            user user = new user();
            privilege privilege = new privilege();

            if (Session["username"] == null)
            {
                if (!ModelState.IsValid)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                
                string extension = Path.GetExtension(UserModel.ImageFile.FileName);
                string fileName = Guid.NewGuid().ToString() + extension;
                var url = System.Configuration.ConfigurationManager.AppSettings["ImageSaveRoute"];
                UserModel.Photo = fileName;
                ////check here
                fileName = Path.Combine(Server.MapPath(url), fileName);

                UserModel.ImageFile.SaveAs(fileName);

                var username = db.users.SingleOrDefault(c => c.username == UserModel.Username);
                var email = db.users.SingleOrDefault(c => c.email == UserModel.Email);
                if (email != null && username != null)
                {
                    ViewBag.UsernameError = "This username exists";
                    ViewBag.EmailError = "This email is exist";
                    return View("Registration");
                }
                else if (username != null)
                {
                    ViewBag.UsernameError = "This username exists";
                    return View("Registration");
                }
                else if (email != null)
                {
                    ViewBag.EmailError = "This email exists";
                    return View("RegisterView");
                }

                //var config = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<Users, user>();
                //});
                //var config = new MapperConfiguration(cfg => cfg.CreateMap<Users, user>());
                //var mapper = config.CreateMapper();
                //Mapper.Map<User>();
                //mapper.Map<List<Models.Privilege>>(ePrivileges);
                //Mapper.Initialize(cfg =>
                //{
                //    cfg.CreateMap<User, Models.User>();
                //    cfg.CreateMap<Privilege, Models.Privilege>();
                //});

                db.users.Add(user);
                db.SaveChanges();

                var usr = db.users.SingleOrDefault(c => c.id == userprev.user.id);
                var priviligie = db.privileges.SingleOrDefault(c => c.privilege1 == "User");
                if (priviligie == null)
                {
                    privilege addprev = new privilege();
                    addprev.privilege1 = "User";
                    db.privileges.Add(addprev);
                    db.SaveChanges();
                    priviligie = db.privileges.SingleOrDefault(c => c.privilege1 == "User");
                }

                privilege.privilege1 = priviligie.privilege1;

                //filling many to many table
                userprev.user_id = usr.id;
                userprev.privilege.id = priviligie.id;
                db.users_privileges.Add(userprev);
                db.SaveChanges();
                // i connect created user with default privilige

                //Create Session
                Session["Current_User"] = new SessionConstructor()
                {
                    Id = usr.id,
                    Privilege = priviligie.privilege1
                };
            }
            else
            {
                ViewBag.UsernameError = "You must log out first";
            }

            return View("Registration");
        }
    }
}