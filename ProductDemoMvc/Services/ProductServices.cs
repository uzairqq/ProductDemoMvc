using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductDemoMvc.Context;
using ProductDemoMvc.DataModels;
using ProductDemoMvc.Models;
using Product = ProductDemoMvc.Models.Product;

namespace ProductDemoMvc.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductServices(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public async Task<bool> AddAsync(Product product)
        {
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        public async Task<List<ProductViewModel>> Get()
        {
            try
            {
                var result = await _applicationDbContext.Products.Select(i => new ProductViewModel()
                {
                    Name = i.Name,
                    OrderId = i.Id,
                    Price = i.Price
                }).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<string> Update(Product product)
        {
            try
            {
                 await _applicationDbContext.Products.Select(i => new ProductViewModel()
                {
                    Name = i.Name,
                    OrderId = i.Id,
                    Price = i.Price
                }).ToListAsync();
                return "Updated";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<string> Delete(int id)
        {
            try
            {
                var findIdInDb = _applicationDbContext.Products.Find(id);
                _applicationDbContext.Products.Remove(findIdInDb);
                _applicationDbContext.SaveChanges();
                return "DEleted";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ProductViewModel> Get(int id)
        {
            try
            {
                try
                {
                    var result = await _applicationDbContext.Products.Select(i => new ProductViewModel()
                    {
                        Name = i.Name,
                        OrderId = i.Id,
                        Price = i.Price
                    }).Where(i=>i.Id==id)
                        .SingleAsync();
                    return result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
