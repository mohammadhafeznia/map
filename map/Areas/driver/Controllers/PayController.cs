using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DataLayer.Context;
using Dto.Payment;
using map.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ZarinPal.Class;
using DataLayer.Entites;
using DataLayer.Context;
using Microsoft.AspNetCore.Http;
using driver.Controllers;
using Microsoft.AspNetCore.Hosting;

namespace  map.driver.Controllers {
    

    public class PayController : BaseController {

        public PayController (Contextdb _db,IWebHostEnvironment env):base(_db,env)
        {
           
         
        }

        public IActionResult Index (int id) 
        {
            Tbl_paydriver A=new Tbl_paydriver()
            {
              Driverid=User.Identity.GetId(),
               Pay=id,
               Paytime=DateTime.UtcNow,
             
                   };
            db.Tbl_paydriver.Add(A);
             db.SaveChanges();
            
           
            return RedirectToAction ("Request","pay",new {area="driver"});

            
        }
        //////////////////////////////////////////////////////////////////فرایند خرید

        public async Task<IActionResult> Request () {

            var quser = db.Tbl_driver.Where (a => a.Id.ToString() == (User.Identity.GetId ())).SingleOrDefault ();
            var qpay=db.Tbl_paydriver.Where(a=>a. Driverid==User.Identity.GetId ()).OrderByDescending(a=>a.Id).Take(1).SingleOrDefault();
           sumshop=qpay.Pay;
            var result = await _payment.Request (new DtoRequest () {
                    Mobile = quser.phone,
                    CallbackUrl = "https://taxijo.com/driver/pay/validate",
                    Description = quser.NameFamily,
                    Email ="tak1.ghasemi@gmail.com",
                    Amount =qpay.Pay,
                    MerchantId = "ab99ecd5-bc8a-402f-8ead-b8dca3ed0e35"
            }, ZarinPal.Class.Payment.Mode.sandbox);
            return Redirect ($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");
        }

        
        ///////////////////////////////////////////////////اعتبار سنجی

        public async Task<IActionResult> Validate (string authority, string status) {

            var verification = await _payment.Verification (new DtoVerification {
                    Amount =sumshop,
                    MerchantId = "ab99ecd5-bc8a-402f-8ead-b8dca3ed0e35",
                    Authority = authority
            }, Payment.Mode.sandbox);

            if (verification.Status == 100) {

                

            var q=db.Tbl_paydriver.OrderByDescending(a=>a.Id).Take(1).SingleOrDefault();
            q.status="شارژ دستی با موفقیت انجام شد"; 
           db.Tbl_paydriver.Update(q);
           db.SaveChanges();
           msg="پرداخت با موفقیت انجام شد";


                return RedirectToAction ("pay","pay");

            } else

            {
                 var q=db.Tbl_paydriver.OrderByDescending(a=>a.Id).Take(1).SingleOrDefault();
             
                db.Tbl_paydriver.Remove(q);
                 db.SaveChanges();
            msg="پرداخت نا موفق بوده است ";
     

                 return RedirectToAction ("pay","pay");

            }

        }



        public IActionResult pay()
        {
          if ( msg !=null)
          {
            
              ViewBag.msg=msg;
               msg=null;
          }

         info();
        
          return View();
        }


      public IActionResult end(int? id)
        {
            var qtravel = db.tbl_Travels.Where(a => a.DriverId == id && a.TypePay == "پذیرش").SingleOrDefault();
            qtravel.TypePay = "اتمام سفر";
             db.tbl_Travels.Update(qtravel);
             db.SaveChanges();
             info();
             return RedirectToAction("pay","pay",new{area="driver"});

        }
        
      }
}

