using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApiUnitTestUdemy.Controllers;
using WebApiUnitTestUdemy.Models;
using WebApiUnitTestUdemy.Repositories.Abstract;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiUnitTestUdemy.Tests
{
    public class ProductControllerTest
    {
        private readonly Mock<IRepository<Product>> _mockrepository;
        private readonly ProductController _controller;
        private List<Product> _products;

        public ProductControllerTest()
        {
            // Mock repository setup
            _mockrepository = new Mock<IRepository<Product>>();

            // Sample data
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "kalen", Price = 100, Description = "egitim" },
                new Product { Id = 2, Name = "Kalemlik", Price = 200, Description = "egitim" },
            };

            // Initialize the controller with the mocked repository
            _controller = new ProductController(_mockrepository.Object);
        }

        [Fact]
        public async Task GetProduct_ActionExecutes_ReturnOkResultWithProduct()
        {
            // Arrange: Setup the mock to return the sample data
            _mockrepository.Setup(x => x.GetAllAsync()).ReturnsAsync(_products);

            // Act: Call the method on the controller
            var result = await _controller.GetProduct();

            // Assert: Verify that the result is of type OkObjectResult
            var okResult = Assert.IsType<OkObjectResult>(result);

            // Assert: Verify the value is a collection of products
            var returnProduct = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);

            // Assert: Verify that the correct number of products is returned
            Assert.Equal<int>(2, returnProduct.ToList().Count);
        }
    }
}
