﻿using FifaShop.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FifaShop.App_Start
{
    public class CartBinder : IModelBinder
    {
        private const string SessionKey = "Cart";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
             Cart cart = null;
             if(controllerContext.HttpContext.Session !=null)
                cart = (Cart)controllerContext.HttpContext.Session[SessionKey];

             if (cart == null)
             {
                 cart = new Cart();
                 if (controllerContext.HttpContext.Session != null)
                     controllerContext.HttpContext.Session[SessionKey] = cart;
             }
             return cart;           
        }

       
    }
}