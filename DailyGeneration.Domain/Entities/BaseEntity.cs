namespace DailyGeneration.Domain.Entities;

public class BaseEntity<TId> where TId : struct
{
    /// <summary>
    /// 主键
    /// </summary>
    public required TId Id { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreateTime { get; set; }

    /// <summary>
    /// 创建人
    /// </summary>
    public TId? CreateById { get; set; }

    /// <summary>
    /// 修改时间
    /// </summary>
    public DateTime? ModifyTime { get; set; }

    /// <summary>
    /// 修改人
    /// </summary>
    public TId? ModifyById { get; set; }

    /// <summary>
    /// 删除时间
    /// </summary>
    public DateTime? DeleteTime { get; set; }

    /// <summary>
    /// 删除人
    /// </summary>
    public TId? DeleteById { get; set; }

    /// <summary>
    /// 软删除标识
    /// </summary>
    public bool IsDelete { get; set; }
}