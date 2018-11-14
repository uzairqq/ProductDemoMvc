using System.Collections.Generic;

namespace ProductDemoMvc.DataModels
{
    public class Product
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string PhysicalPath { get; set; }
        public decimal Price { get; set; }

        public virtual Order Orders { get; set; }
    }
}
