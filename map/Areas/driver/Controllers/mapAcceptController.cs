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
using driver.Controllers;
using Microsoft.AspNetCore.Hosting;

namespace map.driver.Controllers
{
   
    public class mapAcceptController : BaseController
    {
        public mapAcceptController(Contextdb _db,IWebHostEnvironment env):base(_db,env)
        {
           
        }

    
        
        public IActionResult mapAccept(String Phone)
        {
            if (db.tbl_Travels.Any(a => a.UserPhone == Phone && a.TypePay == "search"))
            {
                var qtravel = db.tbl_Travels.Where(a => a.UserPhone == Phone && a.TypePay == "search").FirstOrDefault();
            qtravel.TypePay="پذیرش" ;
            qtravel.DriverId=Convert.ToInt32(User.Identity.GetId());
            db.tbl_Travels.Update(qtravel);
            db.SaveChanges();
            var user=db.tbl_Users.Where(a =>a.phone==Phone).SingleOrDefault();///
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


              
            }//
            }
            ///UserIdentity
           if (db.tbl_Travels.Any(a => a.DriverId.ToString() == User.Identity.GetId() && a.TypePay == "پذیرش"))
            {
              var qtravel = db.tbl_Travels.Where(a => a.DriverId.ToString() == User.Identity.GetId() && a.TypePay == "پذیرش").FirstOrDefault();
             var user=db.tbl_Users.Where(a =>a.phone==qtravel.UserPhone).SingleOrDefault();///
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


              
            }//
            }
                   
                  

                 

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
            db.tbl_Travels.Add(tr);
            db.SaveChanges();
            info();

            return RedirectToAction("load");
        }
        
        



           }
}
