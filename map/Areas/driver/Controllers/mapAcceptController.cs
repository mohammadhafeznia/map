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
namespace map.driver.Controllers
{
    [Area("driver")]
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

        
        public IActionResult mapAccept(String Phone)
        {
            var qtravel = _db.tbl_Travels.Where(a => a.UserPhone == Phone && a.TypePay == "search").FirstOrDefault();
            qtravel.TypePay="پذیرش" ;
            qtravel.DriverId=Convert.ToInt32(User.Identity.GetId());
            _db.tbl_Travels.Update(qtravel);
            _db.SaveChanges();
            var user=_db.tbl_Users.Where(a =>a.phone==Phone).SingleOrDefault();///
            if (user != null)
            {
                 Vm_passenger pass=new Vm_passenger()
            {
                NameFamily=user.NameFamily,
                phone=user.phone,
                Origin=qtravel.Origin,
                Destination=qtravel.Destination,
                photo=user.photo,
                Price=qtravel.Price,


            };
                             return View(pass);


              
            }/////UserIdentity
           
                   



                 return View();


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
