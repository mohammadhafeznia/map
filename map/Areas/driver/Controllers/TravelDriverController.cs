using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Transactions;
using DataLayer.Context;
using DataLayer.Entites;
using DataLayer.Entites;
using Kavenegar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModel;
using DataLayer.Context;
using DataLayer.Entites;
using Microsoft.AspNetCore.Hosting;
using driver.Controllers;

namespace map.driver.Controllers {
    [Area ("driver")]
    public class TravelDriverController : BaseController {
       
        public TravelDriverController (Contextdb _db,IWebHostEnvironment env):base(_db,env)
         {
         }

        public IActionResult TravelDriver () {
           var qlist=db.tbl_Travels.OrderByDescending(a=>a.Id).ToList();
           ViewBag.List=qlist;
            return View ();
        }
        
          public IActionResult TravelDetails () {
            return View ();
        }
               public IActionResult CurrentRequests () {
            return View ();
        }

    }
}