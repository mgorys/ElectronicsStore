using ElectronicsStore.Models.Dto;
using ElectronicsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicsStore.Entities;
using ElectronicsStore.Persistence.Migrations;

namespace ElectronicsStore.Abstractions.IServices
{
    public interface IOrderService
    {
        Task<ServerResponseOrderDateString<IEnumerable<PurchaseItemDto>>> GetOrderByNumberAsync(int number);
        Task<ServerResponseOrderDateString<IEnumerable<PurchaseItemDto>>> ChangeOrderStatusByNumberAsync(ChangeStatusByNumberDto data);
        Task<ServerResponseSuccess<IEnumerable<OrderDto>>> GetOrdersAsync(Query query);
        Task<bool> DeleteOrderByNumberAsync(int number);
        Task<ServerResponseSuccess<IEnumerable<OrderDto>>> GetUsersOrdersAsync(string userEmail, Query query);
        Task<ServerResponseOrderDateString<IEnumerable<PurchaseItemDto>>> GetUsersOrderByIdAsync(string userEmail,int orderNumber);

        
    }
}
