using System;
using System.Collections.Generic;

namespace ProductDemoMvc.DataModels
{
    public class Order
    {
        public int Id { get; set; }
        
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string Name { get; set; }

        public virtual List<Product> Product { get; set; }
    }
}
