using System.Xml.XPath;
using AppProject.Models;
using Business.Services;
using Domain.Extensions;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppProject.Controllers;

public class AuthController(IAuthService authService) : Controller
{

    private readonly IAuthService _authService = authService;
    public IActionResult SignUp()
    {

        return View();
    }

    [HttpPost]
    public async Task<ActionResult> SignUp(SignUpViewModel model)
    {

        ViewBag.ErrorMessage = null;

        if (!ModelState.IsValid)
            return View(model);

        var SignUpFormData = model.MapTo<SignUpFormData>();
        var result = await _authService.SignUpAsync(SignUpFormData);
        if (result.Succeeded)
        {
            return RedirectToAction("SignIn", "Auth");
        }

        ViewBag.ErrorMessage = result.Error;
        return View(model);
    }



    public IActionResult SignIn(string returnUrl = "~/")
    {

        ViewBag.ReturnUrl = returnUrl;

        return View();
    }

    [HttpPost]
    public async Task<ActionResult> SignIn(SignUpViewModel model, string returnUrl = "~/")
    {

        ViewBag.ErrorMessage = null;
        ViewBag.ReturnUrl = returnUrl; 

        if (!ModelState.IsValid)
            return View(model);

        var SignInFormData = model.MapTo<SignInFormData>();
        var result = await _authService.SignInAsync(SignInFormData);
        if (result.Succeeded)
        {
            return LocalRedirect(returnUrl);
        }

        ViewBag.ErrorMessage = result.Error;
        return View(model);
    }

}

