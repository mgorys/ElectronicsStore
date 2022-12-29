using ElectronicsStore.Entities;
using ElectronicsStore.Models;
using ElectronicsStore.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Abstractions.IRepositories
{
    public interface IAccountRepository
    {
        Task<bool> RegisterUserAsync(User registerUser, string password);
        Task<ServerResponse<User>> FindUserAsync(string loginUser);
        void RegisterAdmin(RegisterDto admin);
    }
}
