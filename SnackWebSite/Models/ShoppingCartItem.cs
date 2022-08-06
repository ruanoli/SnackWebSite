using System.ComponentModel.DataAnnotations;

namespace SnackWebSite.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Snack Snack { get; set; } //Chave estrangeira (Posso ter diversos lanches no carrinho de compras)
        public int Quantity { get; set; }

        [StringLength(200)]
        public string ShoppingCartId { get; set; } //Gerar um guid
    }
}
