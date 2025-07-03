using EF_Best_Practices_SmartApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF_Best_Practices_SmartApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Optimized query – only fetch active users.
        /// </summary>
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveUsers()
        {
            var users = await _userService.GetActiveUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// Uses Include to prevent N+1 queries by eager loading orders.
        /// </summary>
        [HttpGet("with-orders")]
        public async Task<IActionResult> GetUsersWithOrders()
        {
            var users = await _userService.GetUsersWithOrders_EagerLoadingAsync();
            return Ok(users);
        }

        /// <summary>
        /// Paginated query using Skip and Take.
        /// </summary>
        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedUsers(int page = 0, int size = 10)
        {
            var users = await _userService.GetPagedUsersAsync(page, size);
            return Ok(users);
        }

        /// <summary>
        /// Uses AsNoTracking for better read performance.
        /// </summary>
        [HttpGet("no-tracking")]
        public async Task<IActionResult> GetUsersNoTracking()
        {
            var users = await _userService.GetUsersNoTrackingAsync();
            return Ok(users);
        }
    }
}