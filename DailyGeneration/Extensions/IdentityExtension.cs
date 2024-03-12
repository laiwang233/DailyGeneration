using System.Security.Claims;
using Entities;
using Microsoft.AspNetCore.Identity;
using OpenIddict.Validation;

namespace DailyGeneration.Extensions;

public static class IdentityExtension
{
    public static async Task SeedAdminUserAsync(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

        await SeedRoleAsync(roleManager);
        await SeedUserAsync(userManager, configuration.GetSection("AdminUser").Get<AdminUserConfig>());
    }

    private class AdminUserConfig
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }

    private static async Task SeedRoleAsync(RoleManager<Role> roleManager)
    {
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            var role = new Role("Admin");
            var res = await roleManager.CreateAsync(role);
            if (!res.Succeeded) throw new Exception("管理员角色创建失败");
        }
    }

    private static async Task SeedUserAsync(UserManager<User> userManager, AdminUserConfig? adminUserConfig)
    {
        if (adminUserConfig != null && await userManager.FindByNameAsync(adminUserConfig.Name) == null)
        {
            var adminUser = new User()
            {
                Name = adminUserConfig.Name,
                UserName = adminUserConfig.Name,
                NormalizedUserName = adminUserConfig.Name.ToUpperInvariant()
            };

            var createRes = await userManager.CreateAsync(adminUser, adminUserConfig.Password);
            var addToRoleRes = await userManager.AddToRoleAsync(adminUser, "Admin");

            if (!createRes.Succeeded || !addToRoleRes.Succeeded) throw new Exception("管理员用户创建失败");

            await userManager.AddClaimAsync(adminUser, new Claim(ClaimTypes.NameIdentifier, adminUser.Id));
        }
    }
}