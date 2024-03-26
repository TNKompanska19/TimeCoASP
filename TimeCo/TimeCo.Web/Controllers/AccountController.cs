using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TimeCo.Data;
using TimeCo.Service.Roles.Services;
using TimeCo.Web.Models;
namespace TimeCo.Web.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IRoleService roleService;
    public AccountController(UserManager<ApplicationUser> userManager, IRoleService roleService)
    {
        this.userManager = userManager;
        this.roleService = roleService;
    }

    [HttpGet("/")]
    public async Task<IActionResult> SignIn()
    {
        if (this.User.Identity.IsAuthenticated)
        {
            var username = this.User.FindFirst(ClaimTypes.Email)?.Value;
            var user = await this.userManager.FindByEmailAsync(username);
            var role = this.roleService.GetRoleByIdAsync(user.RoleId);
            if (role == "User")
            {
                return this.RedirectToAction("Index", "Home", new { username });
            }
            else
            {
                return this.RedirectToAction("CreateSchedule", "Schedule");
            }
        }

        var model = new SignInViewModel();
        return this.View(model);
    }

    [HttpPost("/")]
    public async Task<IActionResult> SignIn(SignInViewModel model)
    {
        if (this.User.Identity.IsAuthenticated)
        {
            return this.RedirectToAction("Index", "Home", new { username = model.Username });
        }

        if (this.ModelState.IsValid)
        {
            var user = await this.userManager.FindByEmailAsync(model.Username);
            if (user == null)
            {
                this.ModelState.AddModelError(string.Empty, "Invalid credentials");
                return this.View(model);
            }

            var isPasswordCorrect = await this.userManager.CheckPasswordAsync(user, model.Password);
            if (!isPasswordCorrect)
            {
                this.ModelState.AddModelError(string.Empty, "Invalid credentials");
                return this.View(model);
            }

            var claims = await this.userManager.GetClaimsAsync(user);
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await this.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal,
                new AuthenticationProperties { IsPersistent = true });

            if (user.RoleId == Guid.Parse("5DAEAB8C-F3E3-462C-9180-92437F5DDD6D"))
            {
                return this.RedirectToAction("Index", "Home", new { username = model.Username });
            }
            else
            {
                return this.RedirectToAction("CreateSchedule", "Schedule");
            }
        }

        return this.View(model);
    }

    [HttpGet("/sign-out")]
    [Authorize]
    public async Task<IActionResult> SignOut()
    {
        await this.HttpContext.SignOutAsync();
        return this.RedirectToAction(nameof(this.SignIn));
    }

    [HttpGet("/sign-up")]
    public async Task<IActionResult> SignUp()
    {
        var model = new SignUpViewModel();
        return this.View(model);
    }

    [HttpPost("/sign-up")]
    public async Task<IActionResult> SignUp(SignUpViewModel model)
    {
        if (this.ModelState.IsValid)
        {
            await this.userManager.CreateAsync(
                new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    EmailConfirmed = true,
                    RoleId = Guid.Parse("5DAEAB8C-F3E3-462C-9180-92437F5DDD6D")
                },
                model.Password);

            return this.RedirectToAction("SignUp", "Account");
        }

        return this.View(model);
    }
}