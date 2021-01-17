using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModel;
using DataLayer.Context;
using DataLayer.Entites;
using map.Models;
using ViewModel;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace map.Controllers
{
    public class ProfileController : Controller
    {
        private readonly Contextdb _db;
     private readonly IHostingEnvironment _env;
        public static string mobile;
        public ProfileController(Contextdb db,IHostingEnvironment env)
        {
            _db = db;
            _env=env;

        }
      

        public IActionResult Index()
        {
            var q=_db.tbl_Users.Where(a=>a.phone==User.Identity.GetId()).SingleOrDefault();


            return View(q);
        }
        //edit
        public IActionResult edit() 
        {
            var q=_db.tbl_Users.Where(a=>a.phone==User.Identity.GetId()).SingleOrDefault();
            Vm_User B=new Vm_User()
            {
                NameFamily=q.NameFamily,
                Adress=q.Adress,
                photo=q.photo,
                phone=q.phone


            };

            
            return View(B);
            


        }



        [HttpPost]
        public async Task<IActionResult> edit(Vm_User A) 
        {
             var q=_db.tbl_Users.Where(a=>a.phone==User.Identity.GetId()).SingleOrDefault();
          if (A.photos!=null)
          {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
                string FileExtension1 = Path.GetExtension(A.photos.FileName);
                string  NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
                var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {

                    await A.photos.CopyToAsync(stream);



                }
               
            q.NameFamily=A.NameFamily;
             q.Adress=A.Adress;
             q.photo=NewFileName; //////////////////////////end upload file
              
          }else
          {
              q.NameFamily=A.NameFamily;
             q.Adress=A.Adress;
            
          }
       
          
           
                
        

             _db.tbl_Users.Update(q);
            _db.SaveChanges();
             

            ///name.photo.credit
            //  Menu.name=_db.tbl_Users.Where(a=>a.phone==User.Identity.GetId())?.SingleOrDefault().NameFamily;
            //  Menu.photo=_db.tbl_Users.Where(a=>a.phone==User.Identity.GetId())?.SingleOrDefault().photo;
            //  //
             HttpContext.Session.SetString ("name", _db.tbl_Users.Where(a=>a.phone==User.Identity.GetId())?.SingleOrDefault().NameFamily);
             HttpContext.Session.SetString ("photo",_db.tbl_Users.Where(a=>a.phone==User.Identity.GetId())?.SingleOrDefault().photo);


            return RedirectToAction("index");
        }
    }
}