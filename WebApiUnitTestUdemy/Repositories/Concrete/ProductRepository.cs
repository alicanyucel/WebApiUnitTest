namespace WebApiUnitTestUdemy.Repositories.Concrete
{
    using System.Collections.Generic;
    using System.Linq;
    using WebApiUnitTestUdemy.Models;
    using WebApiUnitTestUdemy.Repositories.Abstract;

    public class ProductRepository : IProductRepositoy
    {
        private List<Product> _products;

        public ProductRepository()
        {
            // product ekle
            _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.99m },
            new Product { Id = 2, Name = "Product 2", Price = 20.99m },
            new Product { Id = 3, Name = "Product 3", Price = 30.99m }
        };
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = GetById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }

}
