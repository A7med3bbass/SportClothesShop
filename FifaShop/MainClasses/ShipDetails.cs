using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FifaShop.MainClasses
{
    public class ShipDetails
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string AddressA { get; set; }
        public string AddressB { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public bool Gift { get; set; }
       
    }
}