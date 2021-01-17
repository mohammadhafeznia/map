using System.Net.Http.Headers;
using System.Transactions;
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
using ViewModel;
using DataLayer.Entites;
using map.Models;
using driver.Controllers;
using Microsoft.AspNetCore.Hosting;

namespace map.driver.Controllers
{
    [Area("driver")]
    public class mapclientController : BaseController
    {
        public mapclientController(Contextdb _db,IWebHostEnvironment env):base(_db,env)
        {
           
        }


        
        public IActionResult mapclient(String Phone)
        {
            
            var qtravel = db.tbl_Travels.Where(a => a.UserPhone == Phone && a.TypePay == "search").FirstOrDefault();
            info();

                 return View(qtravel);


        }

        public IActionResult AddTravel(Vm_Travel travel)
        {
            Tbl_Travel tr = new Tbl_Travel()
            {
                UserPhone = User.Identity.GetId(),
                Origin = travel.Origin,
                Destination = travel.Destination,
                Distance = travel.Distance,
                Time=travel.Time,
                Price = travel.Price,
                DateDay = DateTime.UtcNow,
                DriverId = 0,
                TypePay = ""


            };
            db.tbl_Travels.Add(tr);
            db.SaveChanges();

            return RedirectToAction("load");
        }
        
        

 //
    public IActionResult Travel () {
            List<Vm_Travel> A=new List<Vm_Travel>();
           var qlist=db.tbl_Travels.Where(a =>a.DriverId.ToString()==User.Identity.GetId()).OrderByDescending(a=>a.Id).ToList();
         
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
           info();
            return View ();
        }
        //
        
          public IActionResult TravelDetails (int id ) {
             var qtravel = db.tbl_Travels.Where(a =>a.Id==id ).FirstOrDefault();
             info();


                 return View(qtravel);
              
          
        }


 


           }
}
