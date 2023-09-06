using EcommerceOfficial.Entities;
using EcommerceOfficial.Interfaces.Repositories;
using EcommerceOfficial.Interfaces.Services;
using EcommerceOfficial.RequestModel;
using EcommerceOfficial.ResponseModel;
using System.Security.Claims;

namespace EcommerceOfficial.Implementation.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IAdminService _adminService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, IAdminService adminService, IHttpContextAccessor httpContextAccessor, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _adminService = adminService;
            _httpContextAccessor = httpContextAccessor;
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponseModel> AddProduct(ProductRequestModel productRequestModel)
        {
            var category = await _categoryRepository.GetCategoryByName(productRequestModel.Category);
            var product = new Product()
            {
                Name = productRequestModel.Name,
                Price = productRequestModel.Price,
                CategoryId = category.Id
            };
            await _productRepository.AddProduct(product);
            return new BaseResponseModel()
            {
                Meassage = "Sucessfull added",
                Status = true
            };
        }
        public async Task<BaseResponseModel> UpdateProduct(int id, ProductRequestModel productRequestModel)
        {
            var category = await _categoryRepository.GetCategoryByName(productRequestModel.Category);
            var product = await _productRepository.GetProductById(id);
            product.Name = productRequestModel.Name;
            product.Price = productRequestModel.Price;
            product.CategoryId = category.Id;
            return new BaseResponseModel()
            {
                Meassage = "Sucessfully uodated",
                Status = false
            };
        }
        public async Task<BaseResponseModel> DeleteProduct(int id)
        {
            await _productRepository.RemoveProduct(id);
            return new BaseResponseModel()
            {
                Meassage = "Sucessfully deleted",
                Status = true
            };
        }
    }
}
