using Microsoft.AspNetCore.Mvc;
using SnackWebSite.Models;
using SnackWebSite.Repositories.Interfaces;
using SnackWebSite.ViewModels;

namespace SnackWebSite.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ISnackRepository _snackRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ISnackRepository snack, ShoppingCart shoppingCart)
        {
            _snackRepository = snack;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
        //Atribuindo os itens obtidos no Carrinho de compras.
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartVM = new ShppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetCartTotal()
            };

            return View(shoppingCartVM);
        }

        public IActionResult AddItemToCart(int snackId)
        {
            var selectSnack = _snackRepository.Snacks.FirstOrDefault(x => x.SnackId == snackId);

            if(selectSnack != null)
            {
                _shoppingCart.AddToCart(selectSnack);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveItemToCart(int snackId)
        {
            var selectedSnack = _snackRepository.Snacks.FirstOrDefault(x => x.SnackId == snackId);

            if(selectedSnack != null)
            {
                _shoppingCart.RemoveToCart(selectedSnack);
            }

            return RedirectToAction("Index");
        } 
    }
}
