using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kırtasiyemalzemem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace kırtasiyemalzemem.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;

        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
             if (!ModelState.IsValid)
            {
                return View(model);

            }

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "Böyle bir kullanıcı yok ");
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Home", "Index");
            }

            return View("~Views/Home/Index.cshtml");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.username,
                Email = model.email


            };

            var result = await _userManager.CreateAsync(user,model.Password);

            if (result.Succeeded)
            {
                //Generate Token
                //Email approvied
                RedirectToAction("Account", "Login");
            }
            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu");
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {

            return View("~/Views/Account/Register.cshtml");
        }

    }
}
