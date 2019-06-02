using FifaShop.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FifaShop.Models
{
    public class ProductModel
    {
       public IEnumerable<Product> prod { get; set; }
       public Pagination Paginations { get; set; }
       public string CurrentCategory { get; set; } 
    }
}