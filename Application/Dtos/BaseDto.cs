namespace Application.Dtos;

public class BaseDto<TId> where TId : IEquatable<TId>
{
    public required TId Id { get; set; }
}