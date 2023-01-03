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
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        
        public async Task<ServerResponseOrderDateString<IEnumerable<PurchaseItemDto>>> GetOrderByNumberAsync(int number)
        {
            var resultDto = new ServerResponseOrderDateString<IEnumerable<PurchaseItemDto>>();
            var result = await _orderRepository.GetOrderByNumberAsync(number);
            if (result.Success == false)
                throw new NotFoundException("Sorry, entities have been not found");
            resultDto.PurchasedItemList = _mapper.Map<IEnumerable<PurchaseItemDto>>(result.PurchasedItemList);
            resultDto.OrderNumber = result.OrderNumber;
            resultDto.Status = result.Status;
            resultDto.TotalWorth = result.TotalWorth;
            resultDto.UserName = result.UserName;
            resultDto.PutDate = ChangeDateTimeFormat(result.PutDate);
            resultDto.Success = result.Success;
            return resultDto;
        }
        public async Task<ServerResponseSuccess<IEnumerable<OrderDto>>> GetOrdersAsync(Query query)
        {
            int pageSize = 5;
            int resultCount = await _orderRepository.GetOrdersCount(query);
            double count = (double)resultCount / (double)pageSize;
            int pagesCount = (int)Math.Ceiling(count);
            query.Page ??= 1;
            if (query.Page < 1 || pagesCount < query.Page)
                throw new BadRequestException("Sorry, page has been not found");
            var resultDto = new ServerResponseSuccess<IEnumerable<OrderDto>>();
            var result = await _orderRepository.GetOrdersAsync(query, pageSize);
            if (result.Success == false)
                throw new NotFoundException("Sorry, entities have been not found");
            resultDto.DataFromServer = _mapper.Map<IEnumerable<OrderDto>>(result.DataFromServer);
            resultDto.Success = result.Success;
            resultDto.PagesCount = pagesCount;
            return resultDto;
        }
        public async Task<ServerResponseOrderDateString<IEnumerable<PurchaseItemDto>>> ChangeOrderStatusByNumberAsync(ChangeStatusByNumberDto data)
        {
            OrderStatus status = data.Status;
            int number = data.Number;
            var result = await _orderRepository.ChangeOrderStatusByNumberAsync(number, status);
            if (result == false)
                throw new NotFoundException("Sorry, entities have been not found");
            var resultDto = await GetOrderByNumberAsync(number);
            return resultDto;
        }
        public string ChangeDateTimeFormat(DateTime date)
        {
            return date.ToString("yyyy-MM-dd hh:mm:ss");
        }
    }
}
