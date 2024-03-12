namespace DailyGeneration.Application.Dtos;

public class LoginDto
{
    public required string UserName { get; set; }

    public required string Password { get; set; }

    public bool RememberMe { get; set; }
}
