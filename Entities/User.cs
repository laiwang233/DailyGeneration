namespace Entities;

/// <summary>
/// 用户
/// </summary>
public class User : BaseEntity<Guid>
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 登录账号
    /// </summary>
    public string Account { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; }
}