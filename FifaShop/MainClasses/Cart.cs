using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FifaShop.MainClasses
{
    public class Cart
    {
        private List<CartLine> listCartLine = new List<CartLine>();

        // Add PRoduct To Cart
        public void AddProducts(Product pro,int Qty=1) 
        {
            CartLine cl = listCartLine
                .Where(P => P.products.pro_id == pro.pro_id)
                .FirstOrDefault();
            if (cl == null)
            {
                listCartLine.Add(new CartLine { products = pro, Quantitty = Qty });
            }
            else
            {
                cl.Quantitty += Qty;
            }
        }

        //Remove Product From Cart
        public void RemoveProduct(Product pro) 
        {
            listCartLine.RemoveAll(P => P.products.pro_id == pro.pro_id);
        }
        //Calc TotalValue In Cart
        public decimal TotalValue() 
        {
            return listCartLine.Sum(P => P.products.pro_price * P.Quantitty);
        }

        //Clear AllList
        public void ClearList() 
        {
            listCartLine.Clear();
        }


        //Get CartList
        public IEnumerable<CartLine> GetAllCart { get { return listCartLine; } }

    }
}