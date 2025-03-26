using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IMovieService _movieService;
        private readonly IOrderService _orderService;
        public OrderController(ShoppingCart shoppingCart, IMovieService movieService, IOrderService orderService)
        {
            _shoppingCart = shoppingCart;
            _movieService = movieService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index() 
        {
            string userId = "";
            var orders = await _orderService.GetOrdersByUserIdAsync(userId);
            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
            };
            return View(response);
        }

        public RedirectToActionResult AddItemToShoppingCart(int id)
        {
            var item = _movieService.GetById(id);
            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public RedirectToActionResult RemoveItemFromShoppingCart(int id)
        {
            var item = _movieService.GetById(id);

            if(item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string emailAddress = "";

            await _orderService.StoreOrderAsync(shoppingCartItems, userId, emailAddress);
            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderComplete");
        }
    }
}
