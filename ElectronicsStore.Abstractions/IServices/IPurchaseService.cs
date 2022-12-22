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
        Task<CartValueDto> PostPurchaseAsync(IEnumerable<PurchaseItemDto> purchaseDto);
    }

}
