using System.Collections.Generic;
using System.Threading.Tasks;
using ProductDemoMvc.DataModels;
using ProductDemoMvc.Models;

namespace ProductDemoMvc.Services
{
    public interface IOrderServices
    {
        Task<bool> AddAsync(Order order);
        Task<List<OrderViewModel>> Get();
    }
}
