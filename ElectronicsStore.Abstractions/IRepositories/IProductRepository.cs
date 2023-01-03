﻿using ElectronicsStore.Entities;
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
        Task<ServerResponseSuccess<IEnumerable<Product>>> GetProductsByCategoryAsync(string category, int? page, int pageSize);
        Task<ServerResponseSuccess<IEnumerable<Product>>> GetProductsBySearchAsync(string search, int? page, int pageSize);
        Task<ServerResponseSuccess<Product>> GetProductByNameAsync(string name);
        Task<int> GetProductsByCategoryCount(string category);
        Task<int> GetProductsBySearchCount(string category);
    }
}
