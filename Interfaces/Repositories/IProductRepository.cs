using EcommerceOfficial.Entities;

namespace EcommerceOfficial.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task RemoveProduct(int id);
        Task<Product> UpdateProduct(Product product);
    }
}