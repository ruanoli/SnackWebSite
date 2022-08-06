using Microsoft.AspNetCore.Mvc;
using SnackWebSite.Models;
using SnackWebSite.ViewModels;

namespace SnackWebSite.Components
{
    public class ShoppingCartSumary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSumary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartVM = new ShppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetCartTotal()
            };

            return View(shoppingCartVM);
        }
    }
}
