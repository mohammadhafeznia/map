using System.ComponentModel;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Data.Common;
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

namespace map.Controllers {

    public class PayController : Controller {
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        public static string msg;
        private readonly Contextdb db;
        public static int sumshop;

        public PayController (Contextdb _db) {
            var expose = new Expose ();
            _payment = expose.CreatePayment ();
            _authority = expose.CreateAuthority ();
            _transactions = expose.CreateTransactions ();
            db = _db;
        }

        public IActionResult Index (int id) 
        {
            Tbl_pay A=new Tbl_pay()
            {
              Phone=User.Identity.GetId(),
               Pay=id,
               Paytime=DateTime.UtcNow

            };
            db.Tbl_pays.Add(A);
             db.SaveChanges();
            
           
            return RedirectToAction ("Request");

            
        }
        //////////////////////////////////////////////////////////////////فرایند خرید

        public async Task<IActionResult> Request () {

            var quser = db.tbl_Users.Where (a => a.phone == (User.Identity.GetId ())).SingleOrDefault ();
            var qpay=db.Tbl_pays.Where(a=>a.Phone==User.Identity.GetId ()).OrderByDescending(a=>a.Id).Take(1).SingleOrDefault();
           sumshop=qpay.Pay;
            var result = await _payment.Request (new DtoRequest () {
                    Mobile = quser.phone,
                    CallbackUrl = "https://taxijo.com/pay/validate",
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

                

            var q=db.Tbl_pays.OrderByDescending(a=>a.Id).Take(1).SingleOrDefault();
           q.status=true; 
           db.Tbl_pays.Update(q);
           db.SaveChanges();
           msg="پرداخت با موفقیت انجام شد";


                return RedirectToAction ("pay","pay");

            } else

            {
                 var q=db.Tbl_pays.OrderByDescending(a=>a.Id).Take(1).SingleOrDefault();
               q.status=false; 
                db.Tbl_pays.Update(q);
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

           HttpContext.Session.SetString ("pay", Diposit().ToString());
        
          return View();
        }



         public int Diposit()
        {
            var user=db.Tbl_pays.Where(a=>a.Phone==User.Identity.GetId ()).ToList();

            int pay=0;
            int harvest=0;
            foreach (var item in user)
            {
                if (item.Pay!=0 && item.status==true)
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


        public IActionResult paytravel()
        {
            var qtravel=db.tbl_Travels.Where(a => a.UserPhone == User.Identity.GetId() && a.TypePay == "پذیرش").SingleOrDefault();
           if (qtravel != null)
           {
                if ( Convert.ToInt32(HttpContext.Session.GetString ("pay"))  >= Convert.ToInt32(qtravel.Price)  )
            {
                 Tbl_pay A=new Tbl_pay()
            {
               Phone=User.Identity.GetId(),
               Harvest=Convert.ToInt32(qtravel.Price),
               havesttime=DateTime.UtcNow,
               idtravel=qtravel.Id

            };
            db.Tbl_pays.Add(A);
             db.SaveChanges();

                    var quser = db.tbl_Users.Where(a => a.phone == qtravel.UserPhone)?.SingleOrDefault();
              Tbl_paydriver B=new Tbl_paydriver()
            {
               Driverid=qtravel.DriverId.ToString(),
               Pay=Convert.ToInt32(qtravel.Price),
               Paytime=DateTime.UtcNow,
                Travelid = qtravel.Id.ToString(),
               NameFamily=quser.NameFamily
                         
               

            };
            db.Tbl_paydriver.Add(B);
             db.SaveChanges();
               HttpContext.Session.SetString ("pay", Diposit().ToString());

             return RedirectToAction ("mapaccept","mapaccept");

              }
              else
              {
                  msg="اعتبار شما کافی نیست لطفا کیف پول خو را شارژ کنید";
                  return RedirectToAction ("pay");


              }
           }
           
           return RedirectToAction ("mapaccept","mapaccept");
        }
        
   }
}

