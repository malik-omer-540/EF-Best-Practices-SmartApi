using EF_Best_Practices_SmartApi.Models;

namespace EF_Best_Practices_SmartApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetActiveUsersAsync();
        Task<List<User>> GetUsersWithOrders_EagerLoadingAsync();
        Task<List<User>> GetPagedUsersAsync(int pageNumber, int pageSize);
        Task<List<User>> GetUsersNoTrackingAsync();
    }
}
