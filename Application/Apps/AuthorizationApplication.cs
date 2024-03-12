using System.Net.Http;
using System.Security.Claims;
using Azure.Core;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Application.Apps;

public class AuthorizationApplication
{
    private readonly UserManager<User> _userManager;

    public AuthorizationApplication(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<User> GetUser(ClaimsPrincipal userClaims)
    {
        var user = await _userManager.GetUserAsync(userClaims);
        if(user == null) throw new AggregateException("找不到用户");

        return user;
    }

    public async Task<User> LoginAsync(LoginDto loginDto)
    {
        if (string.IsNullOrEmpty(loginDto.UserName) || string.IsNullOrEmpty(loginDto.Password)) throw new AggregateException("用户名密码不能为空");

        var user = await _userManager.FindByNameAsync(loginDto.UserName);
        if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password)) throw new AggregateException("用户名或密码不正确");

        return user;
    }
}