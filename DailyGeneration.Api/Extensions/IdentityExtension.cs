using System.Security.Claims;
using DailyGeneration.Domain.Entities;
using Entities;
using Microsoft.AspNetCore.Identity;

namespace DailyGeneration.Api.Extensions;

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
        public required string Name { get; set; }
        public required string Password { get; set; }
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
                UserName = adminUserConfig.Name,
                NormalizedUserName = adminUserConfig.Name.ToUpperInvariant(),
                Account = adminUserConfig.Name,
                Password = adminUserConfig.Password
            };

            var createRes = await userManager.CreateAsync(adminUser, adminUserConfig.Password);
            var addToRoleRes = await userManager.AddToRoleAsync(adminUser, "Admin");

            if (!createRes.Succeeded || !addToRoleRes.Succeeded) throw new Exception("管理员用户创建失败");

            await userManager.AddClaimAsync(adminUser, new Claim(ClaimTypes.NameIdentifier, adminUser.Id));
        }
    }
}