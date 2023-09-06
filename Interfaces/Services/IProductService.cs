using EcommerceOfficial.RequestModel;
using EcommerceOfficial.ResponseModel;

namespace EcommerceOfficial.Interfaces.Services
{
    public interface IProductService
    {
        Task<BaseResponseModel> AddProduct(ProductRequestModel productRequestModel);
        Task<BaseResponseModel> UpdateProduct(int id, ProductRequestModel productRequestModel);
        Task<BaseResponseModel> DeleteProduct(int id);
    }
}