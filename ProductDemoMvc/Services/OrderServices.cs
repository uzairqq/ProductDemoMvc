using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductDemoMvc.Context;
using ProductDemoMvc.DataModels;
using ProductDemoMvc.Models;

namespace ProductDemoMvc.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly ApplicationDbContext _context;

        public OrderServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Order order)
        {
            try
            {
                await _context.Orders.AddAsync(order);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<List<OrderViewModel>> Get()
        {
            try
            {
                var result = await _context.Orders
                    .AsNoTracking()
                    .Select(i => new OrderViewModel()
                    {
                        Name = i.Name,
                        CreatedOn = i.CreatedOn,
                        Id = i.Id
                    }).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
