using AutoMapper;
using Azure;
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

        public async Task<ServerResponseSuccess<ProductDto>> GetProductByNameAsync(string name)
        {
            var resultDto = new ServerResponseSuccess<ProductDto>();
            var result = await _productRepository.GetProductByNameAsync(name);
            if (result.Success == false)
                throw new NotFoundException("Sorry, entity has been not found");
            resultDto.DataFromServer = _mapper.Map<ProductDto>(result.DataFromServer);
            resultDto.Success = result.Success;
            if (resultDto.DataFromServer.Description == null)
                resultDto.DataFromServer.Description = "There is no important data in descr.";
            return resultDto;
        }

        public async Task<ServerResponseSuccess<IEnumerable<ProductDto>>> GetProductsByCategoryAsync(string category, Query query)
        {
            int resultCount = await _productRepository.GetProductsCount(category, query);
            double count = (double)resultCount / (double)query.PageSize;
            int pagesCount = (int)Math.Ceiling(count);
            query.Page ??= 1;
            if(query.Page < 1 || pagesCount < query.Page)
                throw new BadRequestException("Sorry, page has been not found");
            var resultDto = new ServerResponseSuccess<IEnumerable<ProductDto>>();
            var result = await _productRepository.GetProductsByCategoryAsync(category, query);
            if (result.Success == false)
                throw new NotFoundException("Sorry, entities have been not found");
            resultDto.DataFromServer = _mapper.Map<IEnumerable<ProductDto>>(result.DataFromServer);
            resultDto.Success = result.Success;
            resultDto.PagesCount = pagesCount;
            return resultDto;

        }
    }
}
