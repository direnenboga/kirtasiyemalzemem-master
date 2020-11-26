using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;


namespace kırtasiyemalzemem.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            using (var _dbo = new Models.Model())
            {
                var userInfo = (from x in _dbo.Users
                                where x.UserName == userName && x.Password == password || (true) //temp tabi aq //nede olsa burayı silecez commiti
                                select x).FirstOrDefault();




                if (userInfo == null)
                {
                    return View("~/Views/Error/404.cshtml");
                }
                else
                {
                    SessionExtensions.SetString(HttpContext.Session, "UserID", userInfo.Id.ToString());
                    SessionExtensions.SetString(HttpContext.Session, "UserName", userInfo.UserName);
                    return View("~/Views/Home/Index.cshtml");
                }
            }


        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Login/Index.cshtml");
        }
    }
}
