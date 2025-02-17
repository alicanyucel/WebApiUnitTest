

using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApiUnitTestUdemy.Models;
using WebApiUnitTestUdemy.Repositories.Abstract;
using Xunit;

namespace WebApiUnitTestUdemy.Controllers
{
    
    public class ProductTest
    {
        private readonly Mock<IRepository<Product>> _mockrepository;
        private readonly ProductController _controller;
        private List<Product> _products;
        public ProductTest()
        {
            _mockrepository = new Mock<IRepository<Product>>();
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "kalen", Price = 100, Description = "egitim" },
                new Product { Id = 2, Name = "Kalemlik", Price = 200, Description = "egitim" },
            };

        }
        [Fact]
        public async void GetProduct_ActionExecute_ReturnOkResultWithProduct()
        {
            _mockrepository.Setup(x=>x.GetAllAsync()).ReturnsAsync(_products);
            var result=await _controller.GetProduct();
            var okResult=Assert.IsType<OkObjectResult>(result);
            var returnProduct=Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);
            Assert.Equal<int>(2,returnProduct.ToList().Count);

        }
    }
}