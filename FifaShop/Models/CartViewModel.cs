using FifaShop.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FifaShop.Models
{
    public class CartViewModel
    {
        public Cart cart { set; get; }
        public string returnUrl { set; get; }
    }
}