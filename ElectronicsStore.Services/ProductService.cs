using AutoMapper;
using ElectronicsStore.Abstractions.IRepositories;
using ElectronicsStore.Abstractions.IServices;
using ElectronicsStore.Entities;
using ElectronicsStore.Infrastructure.Exceptions;
using ElectronicsStore.Models;
using ElectronicsStore.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ServerResponse<ProductDto>> GetProductByNameAsync(string name)
        {
            var resultDto = new ServerResponse<ProductDto>();
            var result = await _productRepository.GetProductByNameAsync(name);
            if (result.Success == false)
                throw new NotFoundException("Sorry, entity has been not found");
            resultDto.DataFromServer = _mapper.Map<ProductDto>(result.DataFromServer);
            resultDto.Success = result.Success;
            return resultDto;
        }

        public async Task<ServerResponse<IEnumerable<ProductDto>>> GetProductsByCategoryAsync(string category)
        {

            var resultDto = new ServerResponse<IEnumerable<ProductDto>>();
            var result = await _productRepository.GetProductsByCategoryAsync(category);
            if (result.Success == false)
                throw new NotFoundException("Sorry, entities have been not found");
            resultDto.DataFromServer = _mapper.Map<IEnumerable<ProductDto>>(result.DataFromServer);
            resultDto.Success = result.Success;
            return resultDto;

        }
    }
}
