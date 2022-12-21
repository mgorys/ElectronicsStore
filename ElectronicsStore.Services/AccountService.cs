using ElectronicsStore.Entities;
using ElectronicsStore.Models.Dto;
using ElectronicsStore.Models;
using ElectronicsStore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicsStore.Infrastructure.Exceptions;
using Microsoft.Identity.Client;
using ElectronicsStore.Abstractions.IServices;
using ElectronicsStore.Abstractions.IRepositories;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using ElectronicsStore.Models.Authentication;

namespace ElectronicsStore.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(IAccountRepository accountRepository, IMapper mapper, IPasswordHasher<User> passwordHasher, 
            AuthenticationSettings authenticationSettings)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }
        public async Task RegisterUserAsync(RegisterDto registerUser)
        {
            string password = registerUser.Password;
            var newUser = new User();
            newUser = _mapper.Map<User>(registerUser);
            var result = await _accountRepository.RegisterUserAsync(newUser,password);
            if (result == false)
                throw new BadRequestException("Sorry, something went wrong");
        }
        public async Task<LoggedUserInfo> LoginUserAsync(LoginDto login)
        {
            var user = new LoggedUserInfo();
            var userName = await _accountRepository.FindUserAsync(login);
            if (userName.DataFromServer is null)
            {
                throw new BadRequestException("Invalid username or password");
            }
            var token = await GenerateJwt(login);
            user.UserName = userName.DataFromServer.Name;
            user.Token = token;
            return user;
        }
        public async Task<string> GenerateJwt(LoginDto login)
        {
            var user = await _accountRepository.FindUserAsync(login);

            if (user.DataFromServer is null)
            {
                throw new BadRequestException("Invalid username or password");
            }
            var result = _passwordHasher.VerifyHashedPassword(user.DataFromServer, user.DataFromServer.PasswordHash, login.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, $"{user.DataFromServer.Email}"),

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
