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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EStoreDbContext _dbContext;

        public CategoryRepository(EStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ServerResponseSuccess<IEnumerable<Category>>> GetCategoriesAsync()
        {
            var response = new ServerResponseSuccess<IEnumerable<Category>>();
            var result = await _dbContext.Categories
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
