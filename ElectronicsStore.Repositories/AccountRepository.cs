using ElectronicsStore.Entities;
using ElectronicsStore.Models.Dto;
using ElectronicsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ElectronicsStore.Abstractions.IRepositories;
using ElectronicsStore.Persistence;
using Microsoft.AspNetCore.Identity;
using ElectronicsStore.Infrastructure.Exceptions;

namespace ElectronicsStore.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EStoreDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountRepository(EStoreDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }
        public async Task<bool> RegisterUserAsync(User registerUser, string password)
        {
            var newUser = new User()
            {
                Email = registerUser.Email,
                Name = registerUser.Name,
            };

            if (registerUser == null)
            {
                return false;
            }
            else
            {
                var hashedPassword = _passwordHasher.HashPassword(newUser, password);
                newUser.PasswordHash = hashedPassword;
                await _dbContext.Users.AddAsync(newUser);
                await _dbContext.SaveChangesAsync();
            }
            return true;
        }
        public async Task<ServerResponse<User>> FindUserAsync(LoginDto loginUser)
        {
            var response = new ServerResponse<User>();
            var result = await _dbContext.Users.FirstOrDefaultAsync(x=>x.Email == loginUser.Email);
            if (result == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.DataFromServer = result;
            return response;
        }
    }
}
