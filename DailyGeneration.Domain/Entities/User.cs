using Microsoft.AspNetCore.Identity;

namespace DailyGeneration.Domain.Entities;

/// <summary>
/// 用户
/// </summary>
public class User : IdentityUser
{

    /// <summary>
    /// 登录账号
    /// </summary>
    public required string Account { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public required string Password { get; set; }
}