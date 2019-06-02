using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FifaShop.MainClasses
{
    public class Product
    {
        [Key]
        public int pro_id { get; set; }
        public string pro_name { get; set; }
        public decimal pro_price { get; set; }
        public string pro_desc { get; set; }
        public string pro_cat { get; set; }
        public string marca { get; set; }
        public string nation_made { get; set; }
        public int Evaluation { get; set; }
    }
}