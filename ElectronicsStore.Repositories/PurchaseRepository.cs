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
    }
}
