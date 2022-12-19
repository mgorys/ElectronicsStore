using ElectronicsStore.Entities;
using ElectronicsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Abstractions.IRepositories
{
    public interface IProductRepository
    {
        Task<ServerResponse<IEnumerable<Product>>> GetProductsByCategoryAsync(string category);
        Task<ServerResponse<Product>> GetProductByNameAsync(string name);
    }
}
