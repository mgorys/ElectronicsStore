using AutoMapper;
using ElectronicsStore.Abstractions.IRepositories;
using ElectronicsStore.Abstractions.IServices;
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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<ServerResponseSuccess<IEnumerable<CategoryDto>>> GetCategoriesAsync()
        {
            var resultDto = new ServerResponseSuccess<IEnumerable<CategoryDto>>();
            var result = await _categoryRepository.GetCategoriesAsync();
            if (result.Success == false)
                throw new NotFoundException("Sorry, entities have been not found");
            resultDto.DataFromServer = _mapper.Map<IEnumerable<CategoryDto>>(result.DataFromServer);
            resultDto.Success = result.Success;
            return resultDto;
        }

    }
}
