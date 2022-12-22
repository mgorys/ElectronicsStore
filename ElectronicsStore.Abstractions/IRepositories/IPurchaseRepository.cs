using ElectronicsStore.Entities;
using ElectronicsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Abstractions.IRepositories
{
    public interface IPurchaseRepository
    {
        Task<ServerResponse<List<Product>>> GetListOfProductsAsync(IEnumerable<Product> purchase);
    }
}
