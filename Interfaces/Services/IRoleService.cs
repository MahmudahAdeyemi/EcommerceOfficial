using EcommerceOfficial.RequestModel;

namespace EcommerceOfficial.Interfaces.Services
{
    public interface IRoleService
    {
        Task AddRole(RoleRequestModel roleRequestModel);
    }
}