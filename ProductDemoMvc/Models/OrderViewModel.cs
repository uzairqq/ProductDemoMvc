using System;
using System.Collections.Generic;

namespace ProductDemoMvc.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }
    }

    public class OrderGridViewModel
    {
        public OrderViewModel Order { get; set; }
        public List<OrderViewModel> Grid { get; set; }
    }
}
