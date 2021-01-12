using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.Entites;
using Microsoft.AspNetCore.Mvc;
using ViewModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;

namespace map.driver.Controllers {

    [Area ("driver")]

    public class LoginController : Controller {
        private readonly Contextdb _db;
        public static string mobile;
         public static string msg;
        public LoginController (Contextdb db) {
            _db = db;
        }

        public IActionResult Index () {

            if ( msg !=null)
            {
               ViewBag.msg=msg;
                msg=null;
            }
 
            return View ();
        }

        public IActionResult CheckLogin (Vm_driver user)
         {
            var qdriver=_db.Tbl_driver.Where(a => a.Username ==user.Username && a.Password== user.Password).SingleOrDefault();
             
             if (qdriver!=null)
             {
                  var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,qdriver.Id.ToString()),
                    new Claim(ClaimTypes.Name,"driver")
                };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };

                    HttpContext.SignInAsync(principal, properties);
                    return RedirectToAction("privacy", "Home", new { area = "driver" });
                
             }
             else
             {
                  msg="نام کاربری یا رمز عبور شما اشتباه است";

                  
                   return RedirectToAction("index","login",new { area = "driver"});
                  

                  
             }
            return View ();
        }
    }
}