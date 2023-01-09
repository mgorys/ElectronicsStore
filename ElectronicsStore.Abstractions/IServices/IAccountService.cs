using ElectronicsStore.Entities;
using ElectronicsStore.Models;
using ElectronicsStore.Models.Dto;
using ElectronicsStore.Persistence.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Abstractions.IServices
{
    public interface IAccountService
    {
        Task RegisterUserAsync(RegisterDto registerUser);
        Task<string> GenerateJwt(LoginDto dto);
        Task<LoggedUserInfo> LoginUserAsync(LoginDto login);
        Task<ServerResponseSuccess<User>> FindUserAsync(string email);
    }
}
