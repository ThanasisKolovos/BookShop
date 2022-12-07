namespace BookShop.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
