using WebApiUnitTestUdemy.Models;

namespace WebApiUnitTestUdemy.Repositories.Abstract
{
    public interface IProductRepositoy
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
