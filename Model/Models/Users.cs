using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model.Models
{
    public class Users
    {
        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Surname")]
        public string Surname { get; set; }
        [DisplayName("Upload Photo")]
        public string Photo { get; set; }
        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }
        [Required]
        [DisplayName("Telephone")]
        public string Telephone { get; set; }
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "You have to upload File.")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}