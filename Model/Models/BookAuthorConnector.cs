using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
 

namespace Model.Models
{
    public class BookAuthorConnector
    {   
       
        public IEnumerable<SelectListItem> Books;

        public int BookId;
        public string Title;


        public IEnumerable<SelectListItem> Authors;

        public int AuthorId;
        public string Name;
        
    }
}