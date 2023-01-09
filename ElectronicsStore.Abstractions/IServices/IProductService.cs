using ElectronicsStore.Models.Dto;
using ElectronicsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Abstractions.IServices
{
    public interface IProductService
    {
        Task<ServerResponseSuccess<IEnumerable<ProductDto>>> GetProductsByCategoryAsync(string category, Query query);
        Task<ServerResponseSuccess<ProductDto>> GetProductByNameAsync(string name);
    }
}
