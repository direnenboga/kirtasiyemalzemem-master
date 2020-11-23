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

        public IActionResult TryLogin(string userName, string password)
        {
            using (var _dbo = new Models.Model())
            {
                var userInfo = (from x in _dbo.Users
                                where x.UserName == userName && x.Password == password || (true) //temp tabi aq
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
            //string conStr = "";
            //using (MySqlConnection _con = new MySqlConnection(conStr))
            //{
            //    _con.Open();
            //    MySqlCommand _cmd = new MySqlCommand("select * from Users where UserName=@user and Password=@pass", _con);
            //    _cmd.Parameters.AddWithValue("user", userName);
            //    _cmd.Parameters.AddWithValue("pass", password);
            //    var reader = _cmd.ExecuteReader();
            //    if (reader.Read())
            //    {
            //        int uID = Convert.ToInt32(reader["UserID"]);
            //        HttpContext.Session.SetString("UserID", uID.ToString());
            //        return View("~/Views/Home/Index.cshtml");
            //    }
            //    else
            //    {
            //        return View("~/Views/Shared/Error.cshtml");
            //    }
            //}
        }
    }
}
