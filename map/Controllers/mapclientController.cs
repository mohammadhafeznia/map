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
    public class mapclientController : Controller
    {
        private readonly Contextdb _db;
        public static string mobile;
        public mapclientController(Contextdb db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult mapclient(int? id)
        {
            ///name.photo.credit
             Menu.name=_db.tbl_Users.Where(a=>a.phone==User.Identity.GetId())?.SingleOrDefault().NameFamily;
             Menu.photo=_db.tbl_Users.Where(a=>a.phone==User.Identity.GetId())?.SingleOrDefault().photo;
             //

            if (id==0)
            {
                var qtravel = _db.tbl_Travels.Where(a => a.UserPhone == User.Identity.GetId() && a.TypePay == "search").FirstOrDefault();
                if (qtravel != null)
                {
                     qtravel.TypePay = "لغو توسط مسافر";
                     _db.tbl_Travels.Update(qtravel);
                      _db.SaveChanges();
                    
                }
            }
            
            return View();
        }

        public IActionResult acceptmap()
        {
            var qtravel = _db.tbl_Travels.Where(a => a.UserPhone == User.Identity.GetId() && a.TypePay == "ََAccept").FirstOrDefault();
                if (qtravel != null)
                {
                    qtravel.TypePay = "لغو توسط مسافر";
                     _db.tbl_Travels.Update(qtravel);
                      _db.SaveChanges();
                    
                }
            
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
                TypePay = "search"


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
