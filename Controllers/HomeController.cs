using System;
using System.Diagnostics;
using Blog_site.Entities;
using Blog_site.Extentions;
using Blog_site.Repositories;
using Blog_site.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
//using Blog_site.ViewModels;

namespace Blog_site.Controllers
{
    public class HomeController : Controller
    {
        
            public HomeController()
            {
            }

            [HttpGet]
            public IActionResult Index()
            {
                return View();
            }


            public IActionResult Privacy()
            {
                return View();
            }

            [HttpGet]
            public IActionResult MyProfile()
            {
                User loggedUser = this.HttpContext.Session.GetObject<User>("loggedUser");
                MyProfileVM User = new MyProfileVM();

                User.FirstName = loggedUser.FirstName;
                User.LastName = loggedUser.LastName;
                User.Username = loggedUser.Username;
                User.Password = loggedUser.Password;

                return View(User);
            }


            [HttpGet]
            public IActionResult Login(string url)
            {
                LoginVM model = new LoginVM();
                model.Url = url;

                return View(model);
            }

            [HttpPost]
            public IActionResult Login(LoginVM model)
            {
                if (ModelState.IsValid)
                    return View(model);

                UserRepositories repo = new UserRepositories();
                User loggedUser = repo.FirstOrDefault(u =>
                                                    u.Username == model.Username &&
                                                    u.Password == model.Password);

                if (loggedUser == null)
                {
                    ModelState.AddModelError("authFailed", "Authentication failed!");
                    return View(model);
                }

                this.HttpContext.Session.SetObject("loggedUser", loggedUser);

                if (!string.IsNullOrEmpty(model.Url))
                    return new RedirectResult(model.Url);

                return RedirectToAction("Index", "Home");
            }

            public IActionResult Logout()
            {
                this.HttpContext.Session.Remove("loggedUser");

                return RedirectToAction("Index", "Home");
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View();
            }
        
    }
}
