using DailyGeneration.Domain.Entities;

namespace DailyGeneration.Application.Dtos;

public class TodoDto : BaseDto<Guid>
{
    /// <summary>
    /// 名称
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public TodoStatus Status { get; set; }
}