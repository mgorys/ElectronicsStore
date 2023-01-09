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
using ElectronicsStore.Entities.Enums;

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
            int resultCount = await _orderRepository.GetOrdersCount(null, query);
            double count = (double)resultCount / (double)query.PageSize;
            int pagesCount = (int)Math.Ceiling(count);
            query.Page ??= 1;
            if (query.Page < 1 || pagesCount < query.Page)
                throw new BadRequestException("Sorry, page has been not found");
            var resultDto = new ServerResponseSuccess<IEnumerable<OrderDto>>();
            var result = await _orderRepository.GetOrdersAsync(query);
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
        public async Task<bool> DeleteOrderByNumberAsync(int number)
        {
            var result = await _orderRepository.DeleteOrderByNumberAsync(number);
            if (result == false)
                throw new NotFoundException("Sorry, entity has been not found");
            return result;
        }
        public string ChangeDateTimeFormat(DateTime date)
        {
            return date.ToString("yyyy-MM-dd hh:mm:ss");
        }

        public async Task<ServerResponseSuccess<IEnumerable<OrderDto>>> GetUsersOrdersAsync(string email, Query query)
        {
            int resultCount = await _orderRepository.GetOrdersCount(email, query);
            double count = (double)resultCount / (double)query.PageSize;
            int pagesCount = (int)Math.Ceiling(count);
            query.Page ??= 1;
            if (query.Page < 1 || pagesCount < query.Page)
                throw new BadRequestException("Sorry, page has been not found");
            var result = await _orderRepository.GetUsersOrdersAsync(email, query);
            var resultDto = new ServerResponseSuccess<IEnumerable<OrderDto>>();
            if (result.Success == false)
                throw new NotFoundException("Sorry, entities have been not found");
            resultDto.DataFromServer = _mapper.Map<IEnumerable<OrderDto>>(result.DataFromServer);
            resultDto.PagesCount = pagesCount;
            resultDto.Success = result.Success;
            return resultDto;
        }

        public async Task<ServerResponseOrderDateString<IEnumerable<PurchaseItemDto>>> GetUsersOrderByIdAsync(string userEmail, int orderNumber)
        {

            var result = await GetOrderByNumberAsync(orderNumber);
            if (result.UserName == userEmail)
                return result;
            else
                throw new BadRequestException("Order not found");

        }
    }
}
