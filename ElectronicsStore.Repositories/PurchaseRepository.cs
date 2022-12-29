using ElectronicsStore.Abstractions.IRepositories;
using ElectronicsStore.Entities;
using ElectronicsStore.Models;
using ElectronicsStore.Persistence;
using ElectronicsStore.Persistence.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly EStoreDbContext _dbContext;

        public PurchaseRepository(EStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ServerResponse<List<Product>>> GetListOfProductsAsync(IEnumerable<Product> purchase)
        {
            var resultList = new ServerResponse<List<Product>>();
            foreach(var item in purchase)
            {
                var itemToAdd =  await _dbContext.Products.FirstOrDefaultAsync(x=>x.Name == item.Name);
                if(itemToAdd == null)
                {
                    resultList.Success = false;
                    return resultList;
                }
                resultList.DataFromServer.Add(itemToAdd);
            }
            return resultList;
        }
        public async Task<Order> PostPurchaseAsync(IEnumerable<PurchaseItem> purchase, decimal sum, string purchaseOwner)
        {
            string id = DateTime.Now.Month.ToString() + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            var userid = await _dbContext.Users.FirstOrDefaultAsync(x=>x.Email == purchaseOwner);
            var order = new Order()
            {
                OrderNumber = Int32.Parse(id),
                PutDate = DateTime.Now,
                Status = "Created",
                TotalWorth = sum,
                UserId = userid.Id
            };
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            var orderFromDB = await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderNumber == Int32.Parse(id));
            foreach (var item in purchase)
            {
                item.OrderId = order.Id;
                await _dbContext.PurchaseItems.AddAsync(item);
            };
            await _dbContext.SaveChangesAsync();
            return order;
        }
    }
}
