using eTickets.Models;
using Microsoft.AspNetCore.Identity;

namespace eTickets.Data.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<bool> CheckRegisteredStatusAsync()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            bool IsRegistered = user == null;

            _httpContextAccessor.HttpContext?.Session.SetString("IsRegistered", IsRegistered.ToString());
            return IsRegistered;
        }
    }
}
