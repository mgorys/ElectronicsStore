using ElectronicsStore.Entities;
using ElectronicsStore.Models;
using ElectronicsStore.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Abstractions.IServices
{
    public interface ICategoryService
    {
        Task<ServerResponse<IEnumerable<CategoryDto>>> GetCategoriesAsync();
    }
}
