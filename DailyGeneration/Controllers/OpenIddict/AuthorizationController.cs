using Application.Apps;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;

namespace DailyGeneration.Controllers.OpenIddict
{
    [ApiController]
    public class AuthorizationController : Controller
    {
        private readonly IOpenIddictApplicationManager _openIddictApplicationManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AuthorizationApplication _authorizationApplication;

        public AuthorizationController(
            IOpenIddictApplicationManager openIddictApplicationManager,
            SignInManager<User> signInManager,
            AuthorizationApplication authorizationApplication)
        {
            _openIddictApplicationManager = openIddictApplicationManager;
            _signInManager = signInManager;
            _authorizationApplication = authorizationApplication;
        }

        [HttpGet("~/connect/authorize")]
        public async Task<IActionResult> Authorize()
        {
            var request = HttpContext.GetOpenIddictServerRequest() ?? throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");
            
            // 确认用户是否已经登录
            if (!User.Identity?.IsAuthenticated ?? false)
            {
                // 重定向到登录页面
                return Challenge(authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            var user = await _authorizationApplication.GetUser(User);

            // 创建授权码
            if(request.ClientId == null) throw new Exception("客户端Id为空");

            var application = await _openIddictApplicationManager.FindByClientIdAsync(request.ClientId) ??
                              throw new InvalidOperationException("The application details cannot be found.");
            

            var principal = await _signInManager.CreateUserPrincipalAsync(user);
            principal.SetScopes(request.GetScopes());

            // 签发授权码
            return SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        [HttpPost("~/connect/token")]
        public async Task<IActionResult> Token([FromForm] OpenIddictRequest request)
        {
            try
            {
                var user = await _authorizationApplication.LoginAsync(new LoginDto()
                {
                    UserName = request.Username,
                    Password = request.Password
                });

                var principal = await _signInManager.CreateUserPrincipalAsync(user);
                principal.AddClaim("sub", user.Id);

                return SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost("~/login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            await _authorizationApplication.LoginAsync(loginDto);

            return Ok("登录成功");
        }
    }
}
