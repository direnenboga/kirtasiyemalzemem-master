﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using kırtasiyemalzemem.Models;
using Microsoft.AspNetCore.Http;
using kırtasiyemalzemem.Data;

namespace kırtasiyemalzemem.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
   
        public IActionResult Index()
        {
            //if (SessionExtensions.GetString(HttpContext.Session, "UserID") == null)
            //{
            //    return View("~/Views/Login/Index.cshtml");
            //}
            //using (var _dbo = new Model())
            //{
            //    ViewBag.Categories = Json((from x in _dbo.Category
            //                               select x).ToList());
            //}
            return View();
        }
    }
}
