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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ElectronicsStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EStoreDbContext _dbContext;

        public ProductRepository(EStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServerResponse<Product>> GetProductByNameAsync(string name)
        {
            var response = new ServerResponse<Product>();
            var result = await _dbContext.Products
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .FirstOrDefaultAsync(x => x.Name == name);

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

        public async Task<ServerResponse<IEnumerable<Product>>> GetProductsByCategoryAsync(string category, int? page ,int pageSize)
        {
            var response = new ServerResponse<IEnumerable<Product>>();
            var result = await _dbContext.Products
                .Include(x=>x.Category)
                .Include(x=>x.Brand)
                .Where(x=>x.Category.Name == category)
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
        public async Task<ServerResponse<IEnumerable<Product>>> GetProductsBySearchAsync(string search, int? page, int pageSize)
        {
            var response = new ServerResponse<IEnumerable<Product>>();
            var result = await _dbContext.Products
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .Where(x => x.Name.ToLower().Contains(search.ToLower())
                || x.Description.ToLower().Contains(search.ToLower())
                || x.Brand.Name.ToLower().Contains(search.ToLower()))
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
        public async Task<int> GetProductsByCategoryCount(string category)
        {
            var resultCount = await _dbContext.Products.Where(x => x.Category.Name == category).CountAsync();
            return resultCount;
        }
        public async Task<int> GetProductsBySearchCount(string search)
        {
            var resultCount = await _dbContext.Products
            .Include(p=> p.Brand)
                .Where(x=>x.Name.ToLower().Contains(search.ToLower()) 
                || x.Description.ToLower().Contains(search.ToLower()) 
                || x.Brand.Name.ToLower().Contains(search.ToLower()))
                .CountAsync();
            return resultCount;
        }
    }
}
