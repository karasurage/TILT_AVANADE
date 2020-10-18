using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Marraia.Notifications.Base;
using Marraia.Notifications.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TvPlus.Application.AppUser.Input;
using TvPlus.Application.AppUser.Interfaces;
using TvPlus.Api.Signing;
namespace TvPlus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly ILoginAppService _loginAppService;
        private readonly IConfiguration _configuration;

        public LoginController(INotificationHandler<DomainNotification> notification,
            ILoginAppService loginAppService,
            IConfiguration configuration)
            : base(notification)
        {
            _loginAppService = loginAppService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<object> Post([FromBody] LoginInput input,
                                        [FromServices] SigningConfigurations signingConfigurations)
        {
            try
            {
                var logged = await _loginAppService
                                    .LoginAsync(input.Login, input.Password)
                                    .ConfigureAwait(false);

                if (logged != default)
                {
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(logged.Login, "Login"),
                        new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, logged.Id.ToString()),
                        new Claim("Profile", logged.Profile.Description),
                        new Claim("IdProfile", logged.Profile.Id.ToString()),
                        new Claim("NameUser", logged.Name)
                        }
                    );

                    var dateCreated = DateTime.Now;
                    var dateExpiration = dateCreated + TimeSpan.FromSeconds(int.Parse(_configuration["TokenSeconds"]));

                    var handler = new JwtSecurityTokenHandler();
                    var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                    {
                        Issuer = _configuration["TokenIssuer"],
                        Audience = _configuration["TokenAudience"],
                        SigningCredentials = signingConfigurations.SigningCredentials,
                        Subject = identity,
                        NotBefore = dateCreated,
                        Expires = dateExpiration
                    });
                    var token = handler.WriteToken(securityToken);

                    return new
                    {
                        authenticated = true,
                        created = dateCreated.ToString("yyyy-MM-dd HH:mm:ss"),
                        expiration = dateExpiration.ToString("yyyy-MM-dd HH:mm:ss"),
                        accessToken = token,
                        message = "OK"
                    };
                }

                return OkOrNoContent(logged);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " " + ex.InnerException);
            }
        }
    }
}
