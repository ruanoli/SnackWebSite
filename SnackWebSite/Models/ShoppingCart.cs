using Microsoft.EntityFrameworkCore;
using SnackWebSite.Data;

namespace SnackWebSite.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _context;
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            //Define o inicio da sessão
            //Se IHttpContextAcessor não for nulo, ele irá invocar a Session e retorna-la.
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Obtendo um serviço do tipo do meu contexto.
            var context = services.GetService<AppDbContext>();

            //Obtem ou gera o id do carrinho.
            //Se o id do carrinho na sessão for nulo será criado um novo id.
            var cartId = session.GetString("ShoppingCartId") ?? Guid.NewGuid().ToString();

            //Atribui o id no carrinho da sessão
            session.SetString("ShppingCartId", cartId);

            //Retorna o carrinho com o contexto e o id atribuído ou obtido.
            return new ShoppingCart(context)
            {
                ShoppingCartId = cartId
            };
        }

        public void AddToCart(Snack snack)
        {
            //Verifica se o item e o carrinho existem.
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
                x => x.Snack.SnackId == snack.SnackId &&
                x.ShoppingCartId == ShoppingCartId);

            //Se não existir será criado um e adicionará o item no carrinho
            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    Snack = snack,
                    ShoppingCartId = ShoppingCartId,
                    Quantity = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                //se existir, será acrescentado +1 item.
                shoppingCartItem.Quantity++;
            }
            _context.SaveChanges();
        }

        public int RemoveToCart(Snack snack)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
                x => x.Snack.SnackId == snack.SnackId &&
                x.ShoppingCartId == ShoppingCartId);

            int quantityLocal = 0;

            if(shoppingCartItem != null)
            {
               if(shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    quantityLocal = shoppingCartItem.Quantity;
                }
            }
            else
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }

            _context.SaveChanges();

            return (quantityLocal);
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            //Se não existir, será criado um carrinho.
            return ShoppingCartItems ?? 
                (ShoppingCartItems = _context.ShoppingCartItems
                .Where(x => x.ShoppingCartId == ShoppingCartId)
                .Include(x => x.Snack)
                .ToList());
        }

        public void ClearCart()
        {
            var shoppingCartItem = _context.ShoppingCartItems
                .Where(x => x.ShoppingCartId == ShoppingCartId);

            _context.ShoppingCartItems.RemoveRange(shoppingCartItem);

            _context.SaveChanges();
        }

        public decimal GetCartTotal()
        {
            var total = _context.ShoppingCartItems
                .Where(x => x.ShoppingCartId == ShoppingCartId)
                .Select(x => x.Snack.Price * x.Quantity).Sum();

            return total;
        }
    }
}
