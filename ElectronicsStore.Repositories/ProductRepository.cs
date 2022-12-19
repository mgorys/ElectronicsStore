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
    public class ProductRepository : IProductRepository
    {
        private readonly EStoreDbContext _dbContext;

        public ProductRepository(EStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ServerResponse<IEnumerable<Product>>> GetProductsByCategoryAsync(string category)
        {
            var response = new ServerResponse<IEnumerable<Product>>();
            var result = await _dbContext.Products
                .Include(x=>x.Category)
                .Where(x=>x.Category.Name == category)
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
