using EF_Best_Practices_SmartApi.Data;
using EF_Best_Practices_SmartApi.Models;
using EF_Best_Practices_SmartApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EF_Best_Practices_SmartApi.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetActiveUsersAsync()
        {
            return await _context.Users
                .Where(u => u.IsActive)
                .ToListAsync();
        }

        public async Task<List<User>> GetUsersWithOrders_EagerLoadingAsync()
        {
            return await _context.Users
                .Include(u => u.Orders)
                .ToListAsync();
        }

        public async Task<List<User>> GetPagedUsersAsync(int pageNumber, int pageSize)
        {
            return await _context.Users
                .OrderBy(u => u.Id)
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<User>> GetUsersNoTrackingAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
