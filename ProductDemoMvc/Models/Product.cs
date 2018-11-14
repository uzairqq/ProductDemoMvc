using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductDemoMvc.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string PhysicalPath { get; set; }
        public decimal Price { get; set; }
    }
}
