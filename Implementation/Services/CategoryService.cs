using EcommerceOfficial.DTOs;
using EcommerceOfficial.Entities;
using EcommerceOfficial.Interfaces.Repositories;
using EcommerceOfficial.Interfaces.Services;
using EcommerceOfficial.RequestModel;
using EcommerceOfficial.ResponseModel;

namespace EcommerceOfficial.Implementation.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
        public async Task<CategoryResponseModel> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            return new CategoryResponseModel()
            {
                Data = new CategoryDTO
                {
                    Name = category.Name,
                    Products = category.Products
                }
            };
        }
        public async Task<BaseResponseModel> AddCategory(CategoryRequestModel model)
        {
            var category = new Category()
            {
                Name = model.Name
            };
            await _categoryRepository.AddCategory(category);
            return new BaseResponseModel()
            {
                Meassage = "Sucessfully done",
                Status = true
            };
        }
        public async Task DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            foreach (var item in category.Products)
            {
                await _productRepository.RemoveProduct(item.Id);
            }
        }
        public async Task<GetAllCategoriesResponseModel> GetAllCategories()
        {


            return new GetAllCategoriesResponseModel()
            {
                Categories = await _categoryRepository.GetAllCategories()
            };

        }
    }
}
