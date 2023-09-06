using EcommerceOfficial.DTOs;
using EcommerceOfficial.Entities;
using EcommerceOfficial.Interfaces.Services;
using EcommerceOfficial.RequestModel;
using EcommerceOfficial.ResponseModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace EcommerceOfficial.Implementation.Services;

public class AdminService : IAdminService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;


    public AdminService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<LoginResponseModel> Login (LoginRequestModel loginRequestModel)
    {
        if (loginRequestModel is null)
        {
            return new LoginResponseModel
            {
                Meassage = "Information not stored",
                Status = false
            };

        }
        var user = await _userManager.FindByEmailAsync(loginRequestModel.Email);
        if (user is null)
        {
            return new LoginResponseModel
            {
                Meassage = "User Not Found",
                Status = false
            };
        }
        var confirmPassKey = await _userManager.CheckPasswordAsync(user,loginRequestModel.Password);
        if (!confirmPassKey)
        {
            return new LoginResponseModel
            {
                Meassage = "Invalid Password",
                Status = false
            };
        }
        var claims = new List<Claim>
        {
            new Claim(type: ClaimTypes.Email, value: user.Email),
            new Claim(type: ClaimTypes.Name,value: user.LastName),
            new Claim(type: ClaimTypes.Anonymous,value: user.FirstName),
            new Claim(type: ClaimTypes.NameIdentifier,value: user.Id)

        };
        await _signInManager.SignInWithClaimsAsync(user,true,claims);
        await _userManager.AddClaimsAsync(user, claims);
        return new LoginResponseModel
        {
            Data = new LoginDTO()
            {
                Email = loginRequestModel.Email,
                Password = loginRequestModel.Password
            },
            Meassage = "Sucessfully signed in",
            Status = true
        };
        
    }
    public async Task<BaseResponseModel> Register(RegisterUserRequestModel model)
    {
        string filename = null;
        if (model.ProfilePicture != null)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\ProfilePictures\\");
            bool basePathExist = Directory.Exists(basePath);
            if (!basePathExist)
            {
                Directory.CreateDirectory(basePath);
            }
            var newfileName = Path.GetFileNameWithoutExtension(model.ProfilePicture.FileName);
            filename = Path.GetFileName(model.ProfilePicture.FileName);
            var filePath = Path.Combine(basePath, model.ProfilePicture.FileName);
            if (!File.Exists(filePath))
            {
                using var stream = new FileStream(filePath, FileMode.Create);
                await model.ProfilePicture.CopyToAsync(stream);
            }
        }
        var user = new AppUser
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            ProfilePicture = filename,
            UserName = model.Email
        };

        var userMf = await _userManager.CreateAsync(user, model.Password);


        if (!userMf.Succeeded)
        {
            return new BaseResponseModel
            {
                Meassage = userMf.Errors.FirstOrDefault().Description,
                Status = false
            };


        }
        var role = await _userManager.AddToRoleAsync(user, "Admin");
        return new BaseResponseModel
        {
            Meassage = "Sucessfully logged in",
            Status = true
        };


    }
    //public async Task<BaseResponseModel> Update(RegisterUserRequestModel model, string id)
    // {
    //   var user = await _userManager.FindByIdAsync(id);
    // user.FirstName = model.FirstName ?? user.FirstName;
    //       //user.LastName = model.LastName ?? user.LastName;
    //     var userf = await _userManager.UpdateAsync(user);
    //}



}
