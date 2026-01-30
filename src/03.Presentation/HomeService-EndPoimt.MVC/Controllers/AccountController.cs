using Core_HomeService.Domain.Core.UserAgg.Contracts.AppServiceContracts.AccountContract;
using Core_HomeService.Domain.Core.UserAgg.DTOs.ApplicationUserDTOs;
using HomeService_EndPoimt.MVC.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeService_EndPoimt.MVC.Controllers
{
    [AllowAnonymous]
    public class AccountController(IAccountAppService accountAppService) : Controller
    {
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
                return View(model);


            var loginDto = new LoginDto
            {
                UserName = model.UserName,
                Password = model.Password
            };

            var result = await accountAppService.Login(loginDto);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(model);
            }

            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction(nameof(RedirectByRole));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            
            var registerDto = new RegisterDto
            {
                UserName = model.UserName,
                Password = model.Password,
                Role = model.Role
            };

            var result = await accountAppService.Register(registerDto);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(model);
            }

            return RedirectToAction(nameof(Login));
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await accountAppService.Logout();
            return RedirectToAction(nameof(Login));
        }

        [Authorize]
        public IActionResult RedirectByRole()
        {
            if (User.IsInRole("Admin"))
                return RedirectToAction("Index", "Home", new { area = "Admin" });

            if (User.IsInRole("Expert"))
                return RedirectToAction("Index", "Home", new { area = "Expert" });

            return RedirectToAction("Index", "Home", new { area = "Customer" });
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
