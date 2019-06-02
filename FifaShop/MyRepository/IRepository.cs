using FifaShop.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FifaShop.MyRepository
{
   public interface IRepository
    {
        IEnumerable<Product> GetProduct { get; }
    }
}