using FifaShop.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FifaShop.MyHtmlHelper
{
    public static class PaginiationHelper
    {
        public static MvcHtmlString PageLink(this System.Web.Mvc.HtmlHelper Html, Pagination PageInfo, Func<int, string> PageUrl)
        {
            StringBuilder SR = new StringBuilder();

            for (int X = 1; X <= PageInfo.TotalPages; X++)
            {
                TagBuilder T = new TagBuilder("a");
                T.MergeAttribute("href", PageUrl(X));
                T.InnerHtml = X.ToString();
                if (X == PageInfo.CurruntPage)
                {
                    T.AddCssClass("Selected");
                    T.AddCssClass("btn-primary");
                }
                T.AddCssClass("btn btn-default");
                SR.Append(T.ToString());
            }
            return MvcHtmlString.Create(SR.ToString());
        }
    }
}