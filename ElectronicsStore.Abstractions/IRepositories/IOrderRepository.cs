using ElectronicsStore.Entities;
using ElectronicsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Abstractions.IRepositories
{
    public interface IOrderRepository
    {
        Task<ServerResponse<IEnumerable<Order>>> GetOrdersAsync(int? page, int pageSize);
        Task<ServerResponseOrderAndItems<IEnumerable<PurchaseItem>>> GetOrderByNumberAsync(int number);
        Task<int> GetOrdersCount();
    }
}
