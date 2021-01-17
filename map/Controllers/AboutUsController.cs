using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using map.Models;
using ViewModel;
using DataLayer.Context;
using DataLayer.Entites;
using Kavenegar;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace map.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly Contextdb _db;
        public static string mobile;
        public AboutUsController(Contextdb db)
        {
            _db = db;
        }

        public IActionResult AboutUs()
        {
            return View();
        }

    
    }
}
