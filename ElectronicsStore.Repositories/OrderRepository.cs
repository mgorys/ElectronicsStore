using ElectronicsStore.Abstractions.IRepositories;
using ElectronicsStore.Entities;
using ElectronicsStore.Entities.Enums;
using ElectronicsStore.Models;
using ElectronicsStore.Models.Dto;
using ElectronicsStore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EStoreDbContext _dbContext;

        public OrderRepository(EStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServerResponseSuccess<IEnumerable<Order>>> GetOrdersAsync(Query query)
        {
            var response = new ServerResponseSuccess<IEnumerable<Order>>();
            var result = await _dbContext.Orders
                .Include(x => x.User)
                .Where(x => query.Search == null || (x.User.Email.ToLower().Contains(query.Search.ToLower()))
                || x.OrderNumber.ToString().Contains(query.Search))
                .Where(x => query.Status == null ? x.Status != OrderStatus.Archived : x.Status == query.Status)
                .OrderByDescending(x => x.PutDate)
                .Skip(query.PageSize * ((int)(query.Page == null ? 1 : query.Page) - 1))
                .Take(query.PageSize)
                .ToListAsync();

            if (result == null)
            {
                response.Success = false;
                return response;
            }
            else
            {
                response.Success = true;
            }
            response.DataFromServer = result;
            return response;
        }
        public async Task<bool> ChangeOrderStatusByNumberAsync(int number, OrderStatus status)
        {
            var result = await _dbContext.Orders
                .FirstOrDefaultAsync(x => x.OrderNumber == number);

            if (result == null)
                return false;

            result.Status = status;
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<ServerResponseOrder<IEnumerable<PurchaseItem>>> GetOrderByNumberAsync(int number)
        {
            var response = new ServerResponseOrder<IEnumerable<PurchaseItem>>();
            var result = await _dbContext.Orders
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.OrderNumber == number);

            if (result == null)
            {
                response.Success = false;
                return response;
            }
            else
            {
                response.Success = true;
            }
            var purchasedItems = await _dbContext.PurchaseItems.Where(x => x.OrderId == result.Id)
                .Include(x => x.Product)
                .ToListAsync();
            response.UserName = result.User.Email;
            response.TotalWorth = result.TotalWorth;
            response.Status = result.Status;
            response.PutDate = result.PutDate;
            response.OrderNumber = result.OrderNumber;
            response.PurchasedItemList = purchasedItems;

            return response;
        }

        public async Task<int> GetOrdersCount(string? email, Query query)
        {
            var resultCountSearch = await _dbContext.Orders
                .Where(x => query.Search== null
                    || x.User.Email.ToLower().Contains(query.Search.ToLower())
                    || x.OrderNumber.ToString().Contains(query.Search.ToLower()))
                .Where(x => query.Status == null ? x.Status != OrderStatus.Archived : x.Status == query.Status)
                .Where(x => email == null || x.User.Email == email)
                .CountAsync();
                return resultCountSearch;
           }
        public async Task<bool> DeleteOrderByNumberAsync(int number)
        {
            var result = await _dbContext.Orders
                .FirstOrDefaultAsync(x => x.OrderNumber == number);
            if (result == null) return false;
            _dbContext.Orders.Remove(result);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ServerResponseSuccess<IEnumerable<Order>>> GetUsersOrdersAsync(string email, Query query)
        {
            var response = new ServerResponseSuccess<IEnumerable<Order>>();
            var result = await _dbContext.Orders
            .Include(x => x.User)
            .Where(x =>x.User.Email == email)
             .OrderByDescending(x => x.PutDate)
                .Skip(query.PageSize * ((int)(query.Page == null ? 1 : query.Page) - 1))
                .Take(query.PageSize)
                .ToListAsync();

            if (result == null)
            {
                response.Success = false;
                return response;
            }
            else
            {
                response.Success = true;
            }
            response.DataFromServer = result;
            return response;
        }
    }
}
