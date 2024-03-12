using Entities;

namespace DailyGeneration.Dtos;

public class UserDto
{
    /// <summary>
    /// 用户名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///登录账号
    /// </summary>
    public string Account { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; }
}