using System.Security.AccessControl;
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
namespace map.Controllers
{
    
    public class mapAcceptController : Controller
    {
        private readonly Contextdb _db;
        public static string mobile;
        public mapAcceptController(Contextdb db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult mapAccept()
        {
            while (!(_db.tbl_Travels.Any(a => a.UserPhone == User.Identity.GetId() && a.TypePay == "پذیرش")))
            {
                
            }
            var qtravel = _db.tbl_Travels.Where(a => a.UserPhone == User.Identity.GetId() && a.TypePay == "پذیرش").SingleOrDefault();
            var qdriver=_db.Tbl_driver.Where(a =>a.Id==qtravel.DriverId).SingleOrDefault();///
            if (qtravel != null)
            {
                 Vm_passenger pass=new Vm_passenger()
            {
                NameFamily=qdriver.NameFamily,
                phone=qdriver.phone,
                Origin=qtravel.Origin,
                Destination=qtravel.Destination,
                photo=qdriver.profile_img,
                Price=qtravel.Price,
                Typecar=qdriver.type_car,
                pelak=qdriver.pelak,


                 };


                var qpay = _db.Tbl_pays.Where(a => a.idtravel == qtravel.Id).SingleOrDefault();
                if (qpay != null)
                {
                    ViewBag.pay = 1;
                }

                return View(pass);
                             
            


              
            }/////UserIdentity
           
                   
        


                  return RedirectToAction("mapclient","mapclient");


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
            _db.tbl_Travels.Add(tr);
            _db.SaveChanges();

            return RedirectToAction("load");
        }
        
        
 public IActionResult load()
 {
     
     return View();
 }
 


           }
}
