using EcommerceOfficial.Interfaces.Services;
using EcommerceOfficial.RequestModel;
using Microsoft.AspNetCore.Identity;

namespace EcommerceOfficial.Implementation.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task AddRole(RoleRequestModel roleRequestModel)
        {

        var role =  await  _roleManager.CreateAsync(new IdentityRole { Name = roleRequestModel.Name});
        }
    }
}
