using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNET_Web_API_2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}