﻿using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPortal.Controllers.Base;
using WebPortal.Models;

namespace WebPortal.Controllers;

public class AuthController(SignInManager<ApplicationUser> signInManager, LiveMapDbContext context, UserManager<ApplicationUser> userManager)
    : LivemapController
{
    [AllowAnonymous]
    public async Task<IActionResult> Login()
    {
        await signInManager.SignOutAsync();
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = await signInManager.PasswordSignInAsync(model.UserName.ToUpper(), model.Password,
            model.RememberMe, lockoutOnFailure: false);

        var user = await context.Users.FirstOrDefaultAsync(e => e.UserName == model.UserName);
        var ResortId = user.HolidayResortId ?? 1;
        
        HttpContext.Session.SetInt32("resortId", ResortId);

        if (result.Succeeded) return RedirectToAction("Index", "Home");

        ModelState.AddModelError(string.Empty, "De combinatie van gebruikersnaam en wachtwoord is niet geldig.");
        return View(model);
    }
    
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
    
    [AllowAnonymous]
    public IActionResult AccessDenied()
    {
        return View();
    }
}