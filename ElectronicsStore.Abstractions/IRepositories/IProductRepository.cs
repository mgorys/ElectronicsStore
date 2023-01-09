using ElectronicsStore.Entities;
using ElectronicsStore.Models;
using ElectronicsStore.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Abstractions.IRepositories
{
    public interface IProductRepository
    {
        Task<ServerResponseSuccess<IEnumerable<Product>>> GetProductsByCategoryAsync(string category, Query query);
        Task<ServerResponseSuccess<Product>> GetProductByNameAsync(string name);
        Task<int> GetProductsCount(string category, Query query);
    }
}
