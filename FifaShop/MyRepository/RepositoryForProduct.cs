using FifaShop.DataContext;
using FifaShop.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FifaShop.MyRepository
{
    public class RepositoryForProduct:IRepository
    {
        EFdbContext Context = new EFdbContext();
        public IEnumerable<Product> GetProduct
        {
            get {return Context.Products; }
        }
    }
}