using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FifaShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(null, "", new { controller = "Products", Action = "List", prodCat = (string)null, pageno = 1 });    //=====>    URL/

            routes.MapRoute(null, "ProductListPage{pageno}", new { controller = "Products", Action = "List", prodCat = (string)null, }); //===>  URL/ProductListPage2

            routes.MapRoute(null, "{prodCat}", new { controller = "Product", Action = "List", pageno = 1 }); //====>   URL/NIKE

            routes.MapRoute(null, "{prodCat}/Page{pageno}", new { controller = "Products", Action = "List", }, new { pageno = @"\d+" }); //===>   URL/NIKE/Page2 

            routes.MapRoute(name: "Default", url: "{controller}/{action}/{id}", defaults: new { id = UrlParameter.Optional });
        }
    }
}
