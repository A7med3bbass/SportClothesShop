using FifaShop.MainClasses;
using FifaShop.Models;
using FifaShop.MyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FifaShop.Controllers
{
    public class ProductsController : Controller
    {
        IRepository _REPO;
        private int PageSize = 8;
        public ProductsController(IRepository repo) 
        {
            _REPO = repo;
        }
        public ActionResult ListAll()
        {
            return View(_REPO.GetProduct);
        }
        public ActionResult List(string prodCat, int PageNo = 1)
        {
            ProductModel PVM = new ProductModel
            {
                prod = _REPO.GetProduct
                    .Where(P => prodCat == null || P.pro_cat == prodCat)
                    .OrderBy(P => P.pro_id)
                    .Skip((PageNo - 1) * PageSize)
                    .Take(PageSize),
                Paginations = new Pagination
                {
                  CurruntPage = PageNo,
                  ItemPerPage = PageSize,
                  TotalOfItems = prodCat == null? _REPO.GetProduct.Count(): _REPO.GetProduct.Where(P=>P.pro_cat==prodCat).Count()
                
                }, CurrentCategory = prodCat

            };
            return View(PVM);
        }
	}
}