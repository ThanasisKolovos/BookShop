namespace BookShop.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Book book);
        int RemoveFromCart(Book book);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
