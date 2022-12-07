using System.IO.Pipelines;

namespace BookShop.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Book Book { get; set; } = default!;
        public Order Order { get; set; } = default!;
    }
}
