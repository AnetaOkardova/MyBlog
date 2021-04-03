using Microsoft.AspNetCore.Mvc;
using MyBlog.Mappings;
using MyBlog.Services.Interfaces;
using MyBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService _service { get; set; }
        public AuthController(IAuthService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(SignInModel signInModel, string returnUrl)
        {

            var domainModel = signInModel.ToModel();
            if (ModelState.IsValid)
            {
                var response = _service.SignIn(domainModel.Username, domainModel.Password, signInModel.IsPersistent, HttpContext);
                if (response.Success)
                {
                    if (returnUrl == null)
                    {
                        return RedirectToAction("Overview", "Blog");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                }
            }
            return View(signInModel);
        }
        public IActionResult SignOut()
        {
            _service.SignOut(HttpContext);
            return RedirectToAction("Overview", "Blog");
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUpModel signUpModel)
        {
            var domainModel = signUpModel.ToModel();
            if (ModelState.IsValid)
            {
                var response = _service.SignUp(domainModel);
                if (response.Success)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                }
            }

            return View(signUpModel);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
