using System.Reflection.Metadata.Ecma335;

namespace FormsApp.Models
{
    public class Repository
    {
        private static readonly List<Product> _products = new();

        private static readonly List<Category> _categories = new();

        static Repository ()
        {
            _categories.Add(new Category { categoryId = 1, categoryName = "Phone" });
            _categories.Add(new Category { categoryId = 2, categoryName = "Computer" });

            _products.Add(new Product { ProductId = 1, Name = "Samsung Galaxy S21", Price = 18000, Image = "samsung21.jpg", isActive = true, CategoryId = 1 });
            _products.Add(new Product { ProductId = 2, Name = "Iphone 12", Price = 60000, Image = "iphone12.jpg", isActive = true, CategoryId = 1 });
            _products.Add(new Product { ProductId = 3, Name = "Iphone 13",Price = 70000, Image = "iphone13.jpg", isActive = true, CategoryId = 1 });
           
            
            _products.Add(new Product { ProductId = 4, Name = "Dell XPS 13", Price = 25000, Image = "dell.jpg", isActive = true, CategoryId = 2 });
            _products.Add(new Product { ProductId = 5, Name = "Macbook Pro", Price = 60000, Image = "macbook.jpg", isActive = true, CategoryId = 2 });
        }

        public static List<Product> Products 
        {
           get { return _products; }
        }
        
        public static void CreateProduct(Product product)
        {
            _products.Add(product);
        }

        public static List<Category> Categories
        {
            get { return _categories; }
        }

    }
}
