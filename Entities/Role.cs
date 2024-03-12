using Microsoft.AspNetCore.Identity;

namespace Entities;

public class Role : IdentityRole
{
    public Role() : base()
    {
        
    }

    public Role(string name) : base(name)
    {
        
    }
}