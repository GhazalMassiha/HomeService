using Core_HomeService.Domain.Core.UserAgg.Contracts.AppServiceContracts.AccountContract;
using Core_HomeService.Domain.Core.UserAgg.DTOs.ApplicationUserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public async Task<IActionResult> Login(LoginDto dto, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await accountAppService.Login(dto);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(dto);
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
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await accountAppService.Register(dto);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(dto);
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
