namespace BookShop.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Book Book { get; set; } = default!;
        public int Amount { get; set; } 
        public string? ShoppingCartId { get; set; }

    }
}
