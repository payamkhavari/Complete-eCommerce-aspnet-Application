using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext contex)
        {
            _context = contex;
        }
        public async Task<List<Order>> GetOrdersByUserIdAndUserRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Movie).Include(n => n.User).ToListAsync();

            if (userRole != "Admin")
            {
                var userGuid = Guid.Parse(userId);
                orders = orders.Where(n => n.UserId == userGuid).ToList();
            }

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string emailAddress)
        {
            var order = new Order()
            {
                Email = emailAddress,
                UserId = Guid.Parse(userId),
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItems = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price,

                };
                await _context.OrderItems.AddAsync(orderItems);
            }
            await _context.SaveChangesAsync();
        }
    }
}
