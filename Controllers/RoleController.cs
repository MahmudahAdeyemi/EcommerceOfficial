using EcommerceOfficial.Implementation.Services;
using EcommerceOfficial.Interfaces.Services;
using EcommerceOfficial.RequestModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceOfficial.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(RoleRequestModel roleRequestModel)
        {
            await _roleService.AddRole(roleRequestModel);
            return RedirectToAction("Index", "Home");
        }
    }
}
