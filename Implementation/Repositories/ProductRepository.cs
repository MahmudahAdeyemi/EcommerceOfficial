using EcommerceOfficial.Data;
using EcommerceOfficial.Entities;
using EcommerceOfficial.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcommerceOfficial.Implementation.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }
        public async Task<Product> GetProductById(int id)
        {
            return _context.Products.SingleOrDefault(x => x.Id == id);

        }
        public async Task<List<Product>> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        public async Task<Product> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }
        public async Task RemoveProduct(int id)
        {
            var product = _context.Products.Single(x => x.Id == id);
            _context.Products.Remove(product);
        }
    }
}
