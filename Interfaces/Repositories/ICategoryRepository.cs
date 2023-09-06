using EcommerceOfficial.Entities;

namespace EcommerceOfficial.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task AddCategory(Category category);
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategory(int id);
        Task<Category> GetCategoryByName(string name);
        Task<List<Product>> GetProducts(int id);
        Task DeleteProduct(int id);
    }
}