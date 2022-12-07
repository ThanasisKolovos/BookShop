using System.IO.Pipelines;

namespace BookShop.Models
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
           BookShopDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookShopDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Books.Any())
            {
                context.AddRange
                (
                  new Book { Name = "Book1", Price = 22.95M, ShortDescription = "Book1", LongDescription = "Book1 Long Description", Category = Categories["Crime"], ImageUrl = "Images/Book1.png", InStock = true, IsBookOfTheWeek = true, ImageThumbnailUrl = "Images/Book1.png" },
                    new Book { Name = "Book2", Price = 19.95M, ShortDescription = "Book2", LongDescription = "Book2 Long Description", Category = Categories["Crime"], ImageUrl = "Images/Book2.png", InStock = true, IsBookOfTheWeek = true, ImageThumbnailUrl = "Images/Book2.png" },
                    new Book { Name = "Book3", Price = 21.95M, ShortDescription = "Book3", LongDescription = "Book3 Long Description", Category = Categories["Crime"], ImageUrl = "Images/Book3.png", InStock = true, IsBookOfTheWeek = true, ImageThumbnailUrl = "Images/Book3.png" },
                    new Book { Name = "Book4", Price = 21.95M, ShortDescription = "Book4", LongDescription = "Book4 Long Description", Category = Categories["Fantasy"], ImageUrl = "Images/Book4.png", InStock = true, IsBookOfTheWeek = false, ImageThumbnailUrl = "Images/Book4.png" },
                    new Book { Name = "Book5", Price = 29.95M, ShortDescription = "Book5", LongDescription = "Book5 Long Description", Category = Categories["Fantasy"], ImageUrl = "Images/Book5.png", InStock = true, IsBookOfTheWeek = false, ImageThumbnailUrl = "Images/Book5.png" },
                    new Book { Name = "Book6", Price = 12.95M, ShortDescription = "Book6", LongDescription = "Book6 Long Description", Category = Categories["Fantasy"], ImageUrl = "Images/Book6.png", InStock = true, IsBookOfTheWeek = false, ImageThumbnailUrl = "Images/Book6.png" },
                    new Book { Name = "Book7", Price = 18.95M, ShortDescription = "Book7", LongDescription = "Book7 Long Description", Category = Categories["Crime"], ImageUrl = "Images/Book7.png", InStock = true, IsBookOfTheWeek = false, ImageThumbnailUrl = "Images/Book7.png" },
                    new Book { Name = "Book8", Price = 18.95M, ShortDescription = "Book8", LongDescription = "Book8 Long Description", Category = Categories["Crime"], ImageUrl = "Images/Book8.png", InStock = true, IsBookOfTheWeek = false, ImageThumbnailUrl = "Images/Book8.png" },
                    new Book { Name = "Book9", Price = 15.95M, ShortDescription = "Book9", LongDescription = "Book9 Long Description", Category = Categories["Romance"], ImageUrl = "Images/Book9.png", InStock = true, IsBookOfTheWeek = false, ImageThumbnailUrl = "Images/Book9.png" },
                    new Book { Name = "Book10", Price = 13.95M, ShortDescription = "Book10", LongDescription = "Book10 Long Description", Category = Categories["Romance"], ImageUrl = "Images/Book10.png", InStock = true, IsBookOfTheWeek = false, ImageThumbnailUrl = "Images/Book10.png" },
                    new Book { Name = "Book11", Price = 17.95M, ShortDescription = "Book11", LongDescription = "Book11 Long Description", Category = Categories["Romance"], ImageUrl = "Images/Book11.png", InStock = true, IsBookOfTheWeek = false, ImageThumbnailUrl = "Images/Book11.png" },
                    new Book { Name = "Book12", Price = 15.95M, ShortDescription = "Book12", LongDescription = "Book12 Long Description", Category = Categories["Fantasy"], ImageUrl = "Images/Book12.png", InStock = false, IsBookOfTheWeek = false, ImageThumbnailUrl = "Images/Book12.png" },
                    new Book { Name = "Book13", Price = 12.95M, ShortDescription = "Book13", LongDescription = "Book13 Long Description", Category = Categories["Romance"], ImageUrl = "Images/Book13.png", InStock = true, IsBookOfTheWeek = false, ImageThumbnailUrl = "Images/Book13.png" },
                    new Book { Name = "Book14", Price = 15.95M, ShortDescription = "Book14", LongDescription = "Book14 Long Description", Category = Categories["Fantasy"], ImageUrl = "Images/Book14.png", InStock = true, IsBookOfTheWeek = false, ImageThumbnailUrl = "Images/Book14.png" },
                    new Book { Name = "Book15", Price = 15.95M, ShortDescription = "Book15", LongDescription = "Book15 Long Description", Category = Categories["Fantasy"], ImageUrl = "Images/Book15.png", InStock = true, IsBookOfTheWeek = false, ImageThumbnailUrl = "Images/Book15.png" },
                    new Book { Name = "Book16", Price = 18.95M, ShortDescription = "Book16", LongDescription = "Book16 Long Description", Category = Categories["Crime"], ImageUrl = "Images/Book16.png", InStock = false, IsBookOfTheWeek = false, ImageThumbnailUrl = "Images/Book16.png" }
                
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category>? categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Crime" },
                        new Category { CategoryName = "Fantasy" },
                        new Category { CategoryName = "Romance" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}
