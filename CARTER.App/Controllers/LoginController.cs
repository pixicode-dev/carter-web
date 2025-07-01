using CARTER.ApiIntegration.User;
using CARTER.App.Utilities;
using CARTER.Models.Notifications;
using CARTER.Models.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CARTER.App.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;

        public LoginController(IUserApiClient userApiClient, IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var authenticateResult = await _userApiClient.Authenticate(request);

            if (!authenticateResult.Success || authenticateResult.Data.AppUser.Role != "Admin")
            {
                ModelState.AddModelError("", "Email or password incorect");
                return View(request);
            }

            var userPrincipal = this.ValidateToken(authenticateResult.Data.Token);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1),
                IsPersistent = false
            };
            HttpContext.Session.Set<LoginResponse>("LogOn", authenticateResult.Data);
            HttpContext.Session.SetString("DefaultLanguageId", _configuration["DefaultLanguageId"]);
            HttpContext.Session.SetString("Token", authenticateResult.Data.Token);
            await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        userPrincipal,
                        authProperties);

            if (!string.IsNullOrEmpty(request.Timezone))
            {
                var timezoneUpdateResult = await _userApiClient.UpdateNotificationSettings(new NotificationSettingModel { Timezone = request.Timezone, LanguageCode = "fr" });
            }

            return RedirectToAction("Index", "Users");
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Index", "Login");
        }

        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            //IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["JwtBearerTokenSettings:Audience"];
            validationParameters.ValidIssuer = _configuration["JwtBearerTokenSettings:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtBearerTokenSettings:SecretKey"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }


    }


}
