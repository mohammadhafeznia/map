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
namespace map.Controllers {

    public class TravelClientController : Controller {
        private readonly Contextdb _db;
        public static string mobile;
        public TravelClientController (Contextdb db) {
            _db = db;
        }

        public IActionResult TravelClient () {
           var qlist=_db.tbl_Travels.OrderByDescending(a=>a.Id).ToList();
           ViewBag.List=qlist;
            return View ();
        }
          public IActionResult TravelDetails () {
            return View ();
        }

    }
}