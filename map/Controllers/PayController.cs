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

namespace faraboom.Controllers {

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
                    CallbackUrl = "https://localhost:5001/pay/validate",
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


                return RedirectToAction ("pay","pay",new{id=1});
            } else

            {


                 return RedirectToAction ("pay","pay",new{id=0});

            }

        }



        public IActionResult pay(int? id)
        {
          if (id==0)
          {
              ViewBag.msg="پرداخت ناموفق بود ";
          }
          else
          {
              ViewBag.msg="پرداخت موفق بود ";
          }

          return View();
        }
    }
}

