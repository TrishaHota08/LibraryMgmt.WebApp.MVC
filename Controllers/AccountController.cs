using AutoMapper;
using LibraryMgmt.EFCore.Service.DTOs;
using LibraryMgmt.WebApp.MVC.DTOs;
using LibraryMgmt.WebApp.MVC.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace LibraryMgmt.WebApp.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApiHttpClient _apiClient;
        private readonly IMapper _mapper;
        public AccountController(IHttpContextAccessor httpContextAccessor, IMapper mapper, ApiHttpClient apiClient)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _apiClient = apiClient;

        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCredDTO_client cred)
        {
            if (ModelState.IsValid)
            {
                LoginCredDTO loginCred = _mapper.Map<LoginCredDTO>(cred);
                var response = await _apiClient.GetAccessTokenAsync<UserAuthTokenDTO, LoginCredDTO>(loginCred);
                if (response.Data != null)
                {
                    UserAuthTokenDTO_client userCreds = _mapper.Map<UserAuthTokenDTO_client>(response.Data);

                    _httpContextAccessor.HttpContext.Response.Cookies.Append("jwtToken", userCreds.AccessToken);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        //Creating the security context
                        var claims = new List<Claim> {
                    new Claim( ClaimTypes.Name, userCreds.UserName),
                    new Claim(ClaimTypes.Email, userCreds.Email),
                    new Claim(ClaimTypes.Role,userCreds.Role)
                };
                        var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                        return RedirectToAction("Index", "Home");
                    }
                }
                return View("AccessDenied");
            }
            return View();
        }

        public async Task<IActionResult> Retry()
        {
            return RedirectToAction("Login", "Account");
        }

    }
}
