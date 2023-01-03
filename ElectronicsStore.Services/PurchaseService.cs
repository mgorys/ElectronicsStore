using AutoMapper;
using Azure;
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

        public PurchaseService(IPurchaseRepository purchaseRepository, IMapper mapper, IProductRepository productRepository, IAccountRepository accountRepository)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<OrderDto> PostPurchaseAsync(PurchaseDataDto<IEnumerable<PurchaseItemDto>> purchaseDto)
        {
            if (purchaseDto.Email == null)
                throw new BadRequestException("Order should contain email information");
            var purchaseListDto = purchaseDto.PurchaseList;
            if (purchaseListDto == null || purchaseListDto.Count() == 0)
                throw new BadRequestException("Order should contain purchase items");
            var sum = await GetValueOfPurchase(purchaseListDto);

            foreach (var item in purchaseListDto)
            {
                var product = await _productRepository.GetProductByNameAsync(item.Name);
                if(product.DataFromServer == null)
                    throw new NotFoundException($"Item not found {item.Name}");

                item.ProductId = product.DataFromServer.Id;
            }
            var purchaseList = _mapper.Map<IEnumerable<PurchaseItem>>(purchaseListDto);
            var response = await _purchaseRepository.PostPurchaseAsync(purchaseList, sum, purchaseDto.Email);
            var resultDto = _mapper.Map<OrderDto>(response.DataFromServer);
            resultDto.UserName = purchaseDto.Email;
            return resultDto;

        }
        public async Task<decimal> GetValueOfPurchase(IEnumerable<PurchaseItemDto> purchaseDto)
        {
            var purchaseItemsFromDatabase = new List<Product>();
            foreach (var item in purchaseDto)
            {
                var itemMatch = await _productRepository.GetProductByNameAsync(item.Name);
                if (itemMatch.DataFromServer == null)
                    throw new NotFoundException($"Item not found {item}");

                purchaseItemsFromDatabase.Add(itemMatch.DataFromServer);
            }
            decimal sum = 0;
            foreach (var itemFromDatabase in purchaseItemsFromDatabase)
            {
                foreach (var itemFromPurchaseList in purchaseDto)
                {
                    if (itemFromDatabase.Name == itemFromPurchaseList.Name)
                    {
                        sum += itemFromDatabase.Price * itemFromPurchaseList.Count;
                    }
                }
            }
            return sum;
        }
    }
}
