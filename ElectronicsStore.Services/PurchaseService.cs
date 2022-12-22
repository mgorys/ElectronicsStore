using AutoMapper;
using ElectronicsStore.Abstractions.IRepositories;
using ElectronicsStore.Abstractions.IServices;
using ElectronicsStore.Entities;
using ElectronicsStore.Infrastructure.Exceptions;
using ElectronicsStore.Models;
using ElectronicsStore.Models.Dto;
using ElectronicsStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository, IMapper mapper, IProductRepository productRepository)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<CartValueDto> PostPurchaseAsync(IEnumerable<PurchaseItemDto> purchaseDto)
        {
            var purchaseItemsFromDatabase = new List<Product>();
            foreach (var item in purchaseDto)
            {
                var itemMatch = await _productRepository.GetProductByNameAsync(item.Name);
                if(itemMatch.DataFromServer == null)
                    throw new NotFoundException($"Item not found {item}");

                purchaseItemsFromDatabase.Add(itemMatch.DataFromServer);
            }
            decimal sum = 0;
            foreach (var itemFromDatabase in purchaseItemsFromDatabase)
            {
                foreach (var itemFromPurchaseList in purchaseDto)
                {
                    if(itemFromDatabase.Name == itemFromPurchaseList.Name)
                    {
                        sum =sum + itemFromDatabase.Price * itemFromPurchaseList.Count;
                    }
                }
            }
            return new CartValueDto() { Value = sum };
        }
    }
}
