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
using ZarinPal.Class;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace driver.Controllers
{
     [Area("driver")]
    public class BaseController : Controller
    {
              public static string mobile;
          public static string msg;
          
        public readonly Payment _payment;
        public readonly Authority _authority;
        public readonly Transactions _transactions;
        public readonly Contextdb db;
        public static int sumshop;
         public readonly IWebHostEnvironment _env;

        public BaseController(Contextdb _db,IWebHostEnvironment env)
        {
             var expose = new Expose ();
            _payment = expose.CreatePayment ();
            _authority = expose.CreateAuthority ();
            _transactions = expose.CreateTransactions ();
             db = _db;
             _env=env;
        }
     
     public void info()
     {
           HttpContext.Session.SetString ("name",db.Tbl_driver.Where(a=>a.Id.ToString()==User.Identity.GetId())?.SingleOrDefault().NameFamily);
           HttpContext.Session.SetString ("photo",db.Tbl_driver.Where(a=>a.Id.ToString()==User.Identity.GetId())?.SingleOrDefault().profile_img);
           HttpContext.Session.SetString ("pay",Diposit().ToString());

           
           

     }

          public int Diposit()
        {
            var user=db.Tbl_paydriver.Where(a=>a.Driverid==User.Identity.GetId ()).ToList();

            int pay=0;
            int harvest=0;
            foreach (var item in user)
            {
                if (item.Pay !=0 )
                {
                    pay=pay+item.Pay;
                    
                }

                if (item.Harvest!=0)
                {
                    harvest=harvest+item.Harvest;
                }
             
                
            }
            

            int total=pay-harvest;
            return total;
        }
 
       



    }
}