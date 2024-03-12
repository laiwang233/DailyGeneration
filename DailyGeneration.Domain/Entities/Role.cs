using Microsoft.AspNetCore.Identity;

namespace DailyGeneration.Domain.Entities;

public class Role : IdentityRole
{
    public Role() : base()
    {
        
    }

    public Role(string name) : base(name)
    {
        
    }
}