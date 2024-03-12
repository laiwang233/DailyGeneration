using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;

namespace DailyGeneration.Controllers.OpenIddict
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthApplicationController : Controller
    {
        private readonly IOpenIddictApplicationManager _openIddictApplicationManager;

        public AuthApplicationController(IOpenIddictApplicationManager openIddictApplicationManager)
        {
            _openIddictApplicationManager = openIddictApplicationManager;
        }

        /// <summary>
        /// 创建Oauth2 客户端
        /// </summary>
        /// <param name="redirectUris"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="clientId"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateApplication(string clientId, string displayName, List<Uri> redirectUris, CancellationToken cancellationToken)
        {
            if (await _openIddictApplicationManager.FindByClientIdAsync(clientId, cancellationToken) != null) return Ok("客户端已存在");

            var openIddictApplicationDescriptor = new OpenIddictApplicationDescriptor
            {
                ClientId = clientId,
                DisplayName = displayName,
                Permissions =
                {
                    OpenIddictConstants.Permissions.Endpoints.Authorization,
                    OpenIddictConstants.Permissions.GrantTypes.AuthorizationCode,
                    OpenIddictConstants.Permissions.ResponseTypes.Code

                    /*OpenIddictConstants.Permissions.Endpoints.Token,
                    OpenIddictConstants.Permissions.GrantTypes.Password*/
                }
            };
            redirectUris.ForEach(s => openIddictApplicationDescriptor.RedirectUris.Add(s));

            var res = await _openIddictApplicationManager.CreateAsync(openIddictApplicationDescriptor, cancellationToken);

            return Ok(res);
        }
    }
}
