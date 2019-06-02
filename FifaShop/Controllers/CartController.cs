using FifaShop.DataContext;
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
    public class CartController : Controller
    {
        IOrderToProduct _order;
        private IRepository _repo;
        public CartController(IRepository repo,IOrderToProduct order) 
        {
            _repo = repo;
            _order = order;
        }

        public RedirectToRouteResult AddToCart(Cart car,int pro_id ,string RedirectUrl) 
        {
            Product Prod = _repo.GetProduct.FirstOrDefault(P => P.pro_id == pro_id);
            if (Prod != null)
            {
                car.AddProducts(Prod);
            }

            return RedirectToAction("Index", new { RedirectUrl }); // Return To Product Index
        }
        public RedirectToRouteResult RemoveFromCart(Cart car,int pro_id, string RedirectUrl) 
        {
            Product Prod = _repo.GetProduct.FirstOrDefault(P => P.pro_id == pro_id);
            if (Prod != null)
            {
                car.RemoveProduct(Prod);
            }

            return RedirectToAction("Index", new { RedirectUrl }); // Return To Product Index
        }
        public ActionResult Index(Cart car, string RedirectUrl)
        {
            return View(new CartViewModel { cart = car, returnUrl = RedirectUrl });
        }

        public ActionResult CheckOut() 
        {
            return View(new ShipDetails());
        }

        [HttpPost]
        public ActionResult CheckOut(Cart car,ShipDetails ShipDetails)
        {
            if (car.GetAllCart.Count()==0)
                ModelState.AddModelError("","Sorry Your Cart Is Empty");

            if (ModelState.IsValid) 
            {
                _order.OrderProduct(car, ShipDetails);
                car.ClearList();
                return View("Complated");
            }
            else
            {
                return View(ShipDetails);
            }
                          
            
        }



              /*  //=======================================================
                            private Cart GetCart()
                            {
                               Cart cart = (Cart)Session["Cart"];
                               if (cart == null)
                               {
                                   cart = new Cart();
                                   Session["cart"] = cart;
                               }
                               return cart;
                            }
             */  //========================================================
	}
}