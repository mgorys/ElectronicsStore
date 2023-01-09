using ElectronicsStore.Entities;
using ElectronicsStore.Entities.Enums;
using ElectronicsStore.Models;
using ElectronicsStore.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Abstractions.IRepositories
{
    public interface IOrderRepository
    {
        Task<ServerResponseOrder<IEnumerable<PurchaseItem>>> GetOrderByNumberAsync(int number);
        Task<bool> ChangeOrderStatusByNumberAsync(int number, OrderStatus status);
        Task<int> GetOrdersCount(Query query);
        Task<ServerResponseSuccess<IEnumerable<Order>>> GetOrdersAsync(Query query);
        Task<bool> DeleteOrderByNumberAsync(int number);
        Task<ServerResponseSuccess<IEnumerable<Order>>> GetUsersOrdersAsync(string email);
    }
}
