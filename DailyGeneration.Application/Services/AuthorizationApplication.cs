using System.Security.Claims;
using DailyGeneration.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace DailyGeneration.Application.Services;

public class AuthorizationApplication
{
    private readonly UserManager<User> _userManager;

    public AuthorizationApplication(UserManager<User> userManager
        /*SignInManager<IdentityUser> signInManager*/)
    {
        _userManager = userManager;

    }

    public async Task<User> GetUser(ClaimsPrincipal userClaims)
    {
        var user = await _userManager.GetUserAsync(userClaims);
        if (user == null) throw new AggregateException("找不到用户");

        return user;
    }

    /*public async Task<User> LoginAsync(LoginDto loginDto)
    {
        if (string.IsNullOrEmpty(loginDto.UserName) || string.IsNullOrEmpty(loginDto.Password)) throw new AggregateException("用户名密码不能为空");

        var user = await _userManager.FindByNameAsync(loginDto.UserName);
        if (user != null)
        {
            // 使用 SignInManager 进行密码检查和登录
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                // 在这里生成令牌（JWT或其他）并返回给客户端
                // 示例仅返回成功消息
                return Ok(new { message = "登录成功" });
            }
        }
        return Unauthorized(new { message = "登录失败" });
        if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password)) throw new AggregateException("用户名或密码不正确");

        return user;
    }*/
}