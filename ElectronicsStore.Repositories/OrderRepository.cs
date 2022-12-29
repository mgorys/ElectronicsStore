using ElectronicsStore.Abstractions.IRepositories;
using ElectronicsStore.Entities;
using ElectronicsStore.Models;
using ElectronicsStore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EStoreDbContext _dbContext;

        public OrderRepository(EStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ServerResponse<IEnumerable<Order>>> GetOrdersAsync()
        {
            var response = new ServerResponse<IEnumerable<Order>>();
            var result = await _dbContext.Orders
                .Include(x=>x.User)
                .ToListAsync();

            if (result == null)
            {
                response.Success = false;
                return response;
            }
            else
            {
                response.Success = true;
            }
            response.DataFromServer = result;
            return response;
        }
    }
}
