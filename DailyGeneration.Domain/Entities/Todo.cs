namespace DailyGeneration.Domain.Entities
{
    /// <summary>
    /// 待办
    /// </summary>
    public class Todo : BaseEntity<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public TodoStatus Status { get; set; }

        /// <summary>
        /// 用户id 外键
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// 外键实体
        /// </summary>
        public User? User { get; set; }
    }

    /// <summary>
    /// 待办状态
    /// </summary>
    public enum TodoStatus
    {
        /// <summary>
        /// 未开始
        /// </summary>
        NotStarted,

        /// <summary>
        /// 进行中
        /// </summary>
        Ongoing,

        /// <summary>
        /// 已完成
        /// </summary>
        Completed,

        /// <summary>
        /// 已取消
        /// </summary>
        Cancelled
    }
}