using ElectronicsStore.Models.Dto;
using ElectronicsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicsStore.Entities;

namespace ElectronicsStore.Abstractions.IServices
{
    public interface IOrderService
    {
        Task<ServerResponse<IEnumerable<OrderDto>>> GetOrdersAsync(int? page);
        Task<ServerResponseOrderAndItems<IEnumerable<PurchaseItemDto>>> GetOrderByNumberAsync(int number);
    }
}
