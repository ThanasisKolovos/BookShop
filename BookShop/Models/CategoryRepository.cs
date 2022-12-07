namespace BookShop.Models
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly BookShopDbContext _bookShopDbContext;

        public CategoryRepository(BookShopDbContext bookShopDbContext)
        {
            _bookShopDbContext = bookShopDbContext;
        }

        public IEnumerable<Category> AllCategories =>
            _bookShopDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
