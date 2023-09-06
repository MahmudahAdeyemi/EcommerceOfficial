using EcommerceOfficial.RequestModel;
using EcommerceOfficial.ResponseModel;

namespace EcommerceOfficial.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<CategoryResponseModel> GetCategory(int id);
        Task<BaseResponseModel> AddCategory(CategoryRequestModel model);
        Task DeleteCategory(int id);
        Task<GetAllCategoriesResponseModel> GetAllCategories();
    }
}