using FifaShop.MainClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FifaShop.DataContext
{
    public class EFdbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}