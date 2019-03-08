using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Model.Models
{
    public class BookAuthorViewModel
    {
        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Publisher")]
        public string Publisher { get; set; }

        [DisplayName("Publication date")]
        public System.DateTime PublicationDate { get; set; }

        [DisplayName("Authors Name")]
        public string Name { get; set; }
    }
}