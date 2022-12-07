namespace BookShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookShopDbContext _bookShopDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(BookShopDbContext bookShopDbContext, IShoppingCart shoppingCart)
        {
            _bookShopDbContext = bookShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    BookId = shoppingCartItem.Book.BookId,
                    Price = shoppingCartItem.Book.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _bookShopDbContext.Orders.Add(order);

            _bookShopDbContext.SaveChanges();
        }
    }
}
