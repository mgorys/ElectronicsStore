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

        public async Task<ServerResponse<ProductDto>> GetProductByNameAsync(string name)
        {
            var resultDto = new ServerResponse<ProductDto>();
            var result = await _productRepository.GetProductByNameAsync(name);
            if (result.Success == false)
                throw new NotFoundException("Sorry, entity has been not found");
            resultDto.DataFromServer = _mapper.Map<ProductDto>(result.DataFromServer);
            resultDto.Success = result.Success;
            if (resultDto.DataFromServer.Description == null)
                resultDto.DataFromServer.Description = "There is no important data in descr.";


            return resultDto;
        }

        public async Task<ServerResponse<IEnumerable<ProductDto>>> GetProductsByCategoryAsync(string category, int? page)
        {
            int pageSize = 5;
            if (page == null) page = 1;
            if( page < 1 )
                throw new NotFoundException("Sorry, entities have been not found");
            var resultDto = new ServerResponse<IEnumerable<ProductDto>>();
            var result = await _productRepository.GetProductsByCategoryAsync(category,page,pageSize);
            if (result.Success == false)
                throw new NotFoundException("Sorry, entities have been not found");
            resultDto.DataFromServer = _mapper.Map<IEnumerable<ProductDto>>(result.DataFromServer);
            resultDto.Success = result.Success;
            int resultCount = await _productRepository.GetProductsByCategoryCount(category);
            double count = (double)resultCount / (double)pageSize;
            resultDto.PagesCount = (int)Math.Ceiling(count);
            return resultDto;

        }
        public async Task<ServerResponse<IEnumerable<ProductDto>>> GetProductsBySearchAsync(string search, int? page)
        {
            int pageSize = 5;
            if (page == null) page = 1;
            if (page < 1)
                throw new NotFoundException("Sorry, entities have been not found");
            var resultDto = new ServerResponse<IEnumerable<ProductDto>>();
            var result = await _productRepository.GetProductsBySearchAsync(search, page, pageSize);
            if (result.Success == false)
                throw new NotFoundException("Sorry, entities have been not found");
            resultDto.DataFromServer = _mapper.Map<IEnumerable<ProductDto>>(result.DataFromServer);
            resultDto.Success = result.Success;
            int resultCount = await _productRepository.GetProductsBySearchCount(search);
            double count = (double)resultCount / (double)pageSize;
            resultDto.PagesCount = (int)Math.Ceiling(count);
            return resultDto;

        }
    }
}
