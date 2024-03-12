using DailyGeneration.Infrastructure.EntityFrameworkCore;
using OpenIddict.Abstractions;

namespace DailyGeneration.Api.Services;

public static class OpenIddict
{
    public static void OpenIddictConfigureServices(this IServiceCollection services)
    {
        // 注册OpenIddict服务
        services.AddOpenIddict()
            // 配置OpenIddict核心组件
            .AddCore(options =>
            {
                // 配置OpenIddict使用Entity Framework Core存储和管理内部信息
                options.UseEntityFrameworkCore().UseDbContext<TodoDbContext>();
            })
            // 配置OpenIddict授权服务器组件
            .AddServer(options =>
            {
                // 启用授权、令牌、撤销等端点
                options.SetTokenEndpointUris("/connect/token")
                    .SetAuthorizationEndpointUris("/connect/authorize");


                // 指定支持的授权类型
                options.AllowAuthorizationCodeFlow()
                    .AllowPasswordFlow()
                    .AllowRefreshTokenFlow();

                // 注册作用域
                options.RegisterScopes(OpenIddictConstants.Scopes.OpenId);

                // 配置应用程序可以使用的身份验证方案
                options.UseAspNetCore()
                    .EnableTokenEndpointPassthrough()
                    .EnableAuthorizationEndpointPassthrough();

                //生成开发加密证书
                options.AddDevelopmentEncryptionCertificate();
                //生成开发签名证书
                options.AddDevelopmentSigningCertificate();
            })
            // 配置OpenIddict验证组件
            .AddValidation(options =>
            {
                // 使用ASP.NET Core自带的身份验证来验证令牌
                options.UseLocalServer();
                options.UseAspNetCore();
            });

    }
}