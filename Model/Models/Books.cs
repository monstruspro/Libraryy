using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model.Models
{
    public class Books
    {
        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Publisher")]
        public string Publisher { get; set; }

        [Required]
        [DisplayName("Publish Date")]
        public System.DateTime PublicationDate { get; set; }


        public int Id { get; set; }
    }
}