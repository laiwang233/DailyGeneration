using Entities;

namespace Application.Dtos;

public class TodoDto : BaseDto<Guid>
{
    /// <summary>
    /// 名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public TodoStatus Status { get; set; }
}