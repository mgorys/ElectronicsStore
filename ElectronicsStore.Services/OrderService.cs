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
    }
}
