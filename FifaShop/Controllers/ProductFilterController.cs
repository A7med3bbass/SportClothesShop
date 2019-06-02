using FifaShop.MyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FifaShop.Controllers
{
    public class ProductFilterController : Controller
    {
        IRepository _Repo;
        public ProductFilterController(IRepository repo) 
        {
            _Repo = repo;
        }
        //
        // GET: /ProductFilter/
        public PartialViewResult FilterByCategory(string prodCat = null)
        {
            ViewBag.Activate = prodCat;
            IEnumerable<string> Category = _Repo.GetProduct.Select(P => P.pro_cat).Distinct();
            return PartialView(Category);
        }
	}
}