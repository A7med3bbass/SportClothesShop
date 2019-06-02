using FifaShop.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FifaShop.DataContext
{
    public interface IOrderToProduct
    {
        void OrderProduct(Cart car, ShipDetails Ship);
    }
}