using System.Collections.Generic;
using System.Threading.Tasks;
using ProductDemoMvc.DataModels;
using ProductDemoMvc.Models;
using Product = ProductDemoMvc.Models.Product;

namespace ProductDemoMvc.Services
{
    public interface IProductServices
    {
        Task<bool> AddAsync(Product product);
        Task<List<ProductViewModel>> Get();
        Task<string> Update(Product product);
        Task<string> Delete(int id);
        Task<ProductViewModel> Get(int id);
    }
}
