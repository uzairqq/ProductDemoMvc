using System.Collections.Generic;

namespace ProductDemoMvc.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
    }

    public class ProductGridViewModel
    {
        public ProductViewModel Product { get; set; }
        public List<ProductViewModel> Grid { get; set; }
    }
}
