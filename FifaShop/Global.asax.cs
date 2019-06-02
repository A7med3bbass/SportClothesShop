using FifaShop.App_Start;
using FifaShop.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FifaShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);


          //Add Binder
            ModelBinders.Binders.Add(typeof(Cart),new CartBinder());

        }
    }
}
