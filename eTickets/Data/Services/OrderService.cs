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
        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var items = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Movie).
                Where(n => n.UserId == userId).ToListAsync();

            return items;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string emailAddress)
        {
            var order = new Order()
            {
                Email = emailAddress,
                UserId = userId,
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
