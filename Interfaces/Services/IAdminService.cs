using EcommerceOfficial.RequestModel;
using EcommerceOfficial.ResponseModel;

namespace EcommerceOfficial.Interfaces.Services
{
    public interface IAdminService
    {
        Task<LoginResponseModel> Login(LoginRequestModel loginRequestModel);
        Task<BaseResponseModel> Register(RegisterUserRequestModel model);
    }
}