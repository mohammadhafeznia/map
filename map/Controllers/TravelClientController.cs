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
using map.Models;
namespace map.Controllers {

    public class TravelClientController : Controller {
        private readonly Contextdb _db;
        public static string mobile;
        public TravelClientController (Contextdb db) {
            _db = db;
        }

        public IActionResult TravelClient () {
            List<Vm_Travel> A=new List<Vm_Travel>();
           var qlist=_db.tbl_Travels.Where(a =>a.UserPhone==User.Identity.GetId()).OrderByDescending(a=>a.Id).ToList();
         
           foreach (var item in qlist)
           {
                Vm_Travel B=new Vm_Travel()
           {
               Id=item.Id,
               UserPhone=item.UserPhone,
                Origin =item.Origin,
                Destination=item. Destination,
                Distance =item.Distance,
                Price=item.Price,
                Time=item.Time,
                DateDay =item.DateDay,
                DriverId=item.DriverId,
                TypePay=item.TypePay,
                DateShamsi=item.DateDay.ToPersianDateString(),
                
                
           };
           A.Add(B);
           

           }
          
           ViewBag.List=A.OrderByDescending(a=>a.Id);
            return View ();
        }
          public IActionResult TravelDetails (int id ) {
             var qtravel = _db.tbl_Travels.Where(a =>a.Id==id ).FirstOrDefault();


                 return View(qtravel);
              
          
        }

    }
}