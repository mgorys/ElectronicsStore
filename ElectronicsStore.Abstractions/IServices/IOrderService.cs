using ElectronicsStore.Models.Dto;
using ElectronicsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Abstractions.IServices
{
    public interface IOrderService
    {
        Task<ServerResponse<IEnumerable<OrderDto>>> GetOrdersAsync();
    }
}
