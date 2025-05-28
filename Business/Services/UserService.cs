using Business.Models;
using Data.Entitites;
using Data.Repositories;
using Domain.Extensions;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class UserService(IUserRepository userRepository, UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager)
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;

    public async Task<UserResult> GetUsersAsync()
    {

        var result = await _userRepository.GetAllAsync();
        return result.MapTo<UserResult>();


    }

    public async Task<UserResult> AddUserTorole(string userId, string roleName)
    {
        if (!await _roleManager.RoleExistsAsync(roleName))
            return new UserResult { Succeeded = false, StatusCode = 404, Error = "Role does not exist." };

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return new UserResult { Succeeded = false, StatusCode = 404, Error = "User does not exist." };

        var result = await _userManager.AddToRoleAsync(user, roleName)
        return result.MapTo<UserResult>();
    }
}
