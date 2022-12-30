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
        public async Task<ServerResponse<IEnumerable<Order>>> GetOrdersAsync(int? page, int pageSize)
        {
            var response = new ServerResponse<IEnumerable<Order>>();
            var result = await _dbContext.Orders
                .Include(x=>x.User)
                .Skip(pageSize * ((int)(page == null ? 1 : page) - 1))
                .Take(pageSize)
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
        public async Task<ServerResponseOrderAndItems<IEnumerable<PurchaseItem>>> GetOrderByNumberAsync(int number)
        {
            var response = new ServerResponseOrderAndItems<IEnumerable<PurchaseItem>>();
            var result = await _dbContext.Orders
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.OrderNumber == number);

            if (result == null)
            {
                response.Success = false;
                return response;
            }
            else
            {
                response.Success = true;
            }
            var purchasedItems = await _dbContext.PurchaseItems.Where(x => x.OrderId == result.Id)
                .Include(x=>x.Product)
                .ToListAsync();
            response.UserName = result.User.Email;
            response.TotalWorth = result.TotalWorth;
            response.Status = result.Status;
            response.PutDate = result.PutDate;
            response.OrderNumber = result.OrderNumber;
            response.PurchasedItemList = purchasedItems;

            return response;
        }
        public async Task<int> GetOrdersCount()
        {
            var resultCount = await _dbContext.Orders.CountAsync();
            return resultCount;
        }
    }
}
