using ElectronicsStore.Abstractions.IRepositories;
using ElectronicsStore.Abstractions.IServices;
using ElectronicsStore.Infrastructure.Exceptions;
using ElectronicsStore.Models.Dto;
using ElectronicsStore.Models;
using ElectronicsStore.Persistence;
using ElectronicsStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ElectronicsStore.Entities;

namespace ElectronicsStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly EStoreDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(EStoreDbContext dbContext, IOrderRepository orderRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<ServerResponse<IEnumerable<OrderDto>>> GetOrdersAsync()
        {
            var resultDto = new ServerResponse<IEnumerable<OrderDto>>();
            var result = await _orderRepository.GetOrdersAsync();
            if (result.Success == false)
                throw new NotFoundException("Sorry, entities have been not found");
            resultDto.DataFromServer = _mapper.Map<IEnumerable<OrderDto>>(result.DataFromServer);
            resultDto.Success = result.Success;
            return resultDto;
        }
        public async Task<ServerResponseOrderAndItems<IEnumerable<PurchaseItemDto>>> GetOrderByNumberAsync(int number)
        {
            var resultDto = new ServerResponseOrderAndItems<IEnumerable<PurchaseItemDto>>();
            var result = await _orderRepository.GetOrderByNumberAsync(number);
            if (result.Success == false)
                throw new NotFoundException("Sorry, entities have been not found");
            resultDto.PurchasedItemList = _mapper.Map<IEnumerable<PurchaseItemDto>>(result.PurchasedItemList);
            resultDto.OrderNumber = result.OrderNumber;
            resultDto.Status = result.Status;
            resultDto.TotalWorth = result.TotalWorth;
            resultDto.UserName = result.UserName;
            resultDto.PutDate = result.PutDate;
            resultDto.Success = result.Success;
            return resultDto;
        }
    }
}
