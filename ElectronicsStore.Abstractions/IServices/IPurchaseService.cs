using ElectronicsStore.Models;
using ElectronicsStore.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Abstractions.IServices
{
    public interface IPurchaseService
    {
        Task<OrderDto> PostPurchaseAsync(PurchaseDataDto<IEnumerable<PurchaseItemDto>> purchaseDto);
        Task<decimal> GetValueOfPurchase(IEnumerable<PurchaseItemDto> purchaseDto);
    }

}
