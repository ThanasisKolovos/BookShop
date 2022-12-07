namespace BookShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Adventure stories", Description="Adventure stories"},
                new Category{CategoryId=2, CategoryName="Crime", Description="Crime"},
                new Category{CategoryId=3, CategoryName="Fantasy", Description="Fantasy"}
            };
    }
}
