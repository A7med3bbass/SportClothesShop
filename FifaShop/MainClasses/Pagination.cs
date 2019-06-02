using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FifaShop.MainClasses
{
    public class Pagination
    {
        public int TotalOfItems { get; set; }
        public int ItemPerPage { get; set; }
        public int CurruntPage { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalOfItems / ItemPerPage); }
        }
    }
}