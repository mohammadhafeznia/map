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

namespace map.driver.Controllers
{
     [Area("driver")]
    public class HomeController : Controller
    {
        private readonly Contextdb _db;
        public static string mobile;
        public HomeController(Contextdb db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult intro()
        {

            return View();
        }
        public IActionResult otp()
        {
            if (User.Identity.IsAuthenticated)
            {
                  return RedirectToAction("mapclient","mapclient");
            }

            return View();
        }

        public IActionResult mapclient()
        {
           
            return View();
        }

      public IActionResult otpconfig()
      {
            ViewBag.Mobile=mobile;
          return View();
      }
      

        [HttpPost]
        public IActionResult otpconfig(Vm_User us)
        {
           ViewBag.Mobile=mobile;
            var q=_db.tbl_Users.Where(a =>a.phone==mobile).SingleOrDefault();
            if (q.token==us.token)
            {
                           var claims = new List<Claim> () {
                            new Claim (ClaimTypes.NameIdentifier,q.phone),
                            new Claim (ClaimTypes.Name, "")
                            };

                            var identity = new ClaimsIdentity (claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            var principal = new ClaimsPrincipal (identity);

                            var properties = new AuthenticationProperties {
                                IsPersistent = true
                            };

                            HttpContext.SignInAsync (principal, properties);
                           

               return RedirectToAction("mapclient","mapclient");
            }else
            {
                ViewBag.msg="رمز وردی نادرست است";
                return View();
            }


            return View();
        }
        public IActionResult sendtoken(Vm_User us)
        {
            Random rnd = new Random();
            string number = rnd.Next(1000, 9999).ToString();
            mobile=us.phone;
            var qcheck = _db.tbl_Users.Where(a => a.phone == us.phone).SingleOrDefault();
            if (qcheck == null)
            {
                Tbl_User user = new Tbl_User()
                {
                    phone = us.phone,
                    token = "1234"
                };
                _db.tbl_Users.Add(user);
                _db.SaveChanges();

                // var api = new KavenegarApi("3871353043697339486A70384F544A4A574C74612B51432F4C7A4B305076645457396F5267456F7A5A34383D");
                // api.VerifyLookup(us.phone, number, "taxijo");
                return RedirectToAction("otpconfig");

            }else
            {
                qcheck.token="1234";
                 _db.tbl_Users.Update(qcheck);
                _db.SaveChanges();

                // var api = new KavenegarApi("3871353043697339486A70384F544A4A574C74612B51432F4C7A4B305076645457396F5267456F7A5A34383D");
                // api.VerifyLookup(us.phone, number, "taxijo");
                return RedirectToAction("otpconfig");

            }




            return RedirectToAction("otpconfig");
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
