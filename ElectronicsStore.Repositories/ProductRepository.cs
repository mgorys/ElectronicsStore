using ElectronicsStore.Abstractions.IRepositories;
using ElectronicsStore.Entities;
using ElectronicsStore.Models;
using ElectronicsStore.Models.Dto;
using ElectronicsStore.Models.Enums;
using ElectronicsStore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
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

        public async Task<ServerResponseSuccess<Product>> GetProductByNameAsync(string name)
        {
            var response = new ServerResponseSuccess<Product>();
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

        public async Task<ServerResponseSuccess<IEnumerable<Product>>> GetProductsByCategoryAsync(string category, Query query)
        {
            var response = new ServerResponseSuccess<IEnumerable<Product>>();
            var result = new List<Product>();

            var baseQuery = _dbContext.Products
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .Where(x => x.Category.Name == category)
                .Where(query.Search != null ? x => x.Name.ToLower().Contains(query.Search.ToLower())
                            || x.Description.ToLower().Contains(query.Search.ToLower())
                            || x.Brand.Name.ToLower().Contains(query.Search.ToLower()) : x=> x.Name != query.Search);

            baseQuery = query.SortDirection == SortDirection.ASC
                    ? baseQuery.OrderBy(x=>x.Price)
                    : baseQuery.OrderByDescending(x => x.Price);

            result = await baseQuery
                .Skip(query.PageSize * ((int)(query.Page == null ? 1 : query.Page) - 1))
                .Take(query.PageSize)
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
        public async Task<int> GetProductsCount(string category, Query query)
        {
            var resultCount = await _dbContext.Products.Where(x => x.Category.Name == category)
                .Include(p => p.Brand)
                .Where(query.Search != null ? x => x.Name.ToLower().Contains(query.Search.ToLower())
                || x.Description.ToLower().Contains(query.Search.ToLower())
                || x.Brand.Name.ToLower().Contains(query.Search.ToLower()) : x=>x.Name != query.Search)
                .CountAsync();
            return resultCount;
        }
    }
}
