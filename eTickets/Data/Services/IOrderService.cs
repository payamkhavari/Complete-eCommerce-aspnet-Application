using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items , string userId,string emailAddress);
        Task<List<Order>> GetOrdersByUserIdAndUserRoleAsync(string userId, string userRole);
    }
}
