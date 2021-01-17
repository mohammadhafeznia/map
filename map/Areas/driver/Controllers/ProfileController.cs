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
using driver.Controllers;

namespace map.driver.Controllers
{    [Area("driver")]
    public class ProfileController : BaseController
    {
        public ProfileController(Contextdb _db,IWebHostEnvironment env):base(_db,env)
        {
          

        }
      

        public IActionResult Index()
        {
            var q=db.Tbl_driver.Where(a=>a.Id.ToString()==User.Identity.GetId()).SingleOrDefault();


            return View(q);
        }
        //edit
        public IActionResult edit() 
        {
            var q=db.Tbl_driver.Where(a=>a.Id.ToString()==User.Identity.GetId()).SingleOrDefault();
            Vm_driver B=new Vm_driver()
            {
                NameFamily=q.NameFamily,
                Adress=q.Adress,
                profile_img=q.profile_img,
                phone=q.phone


            };

            
            return View(B);
            


        }



        [HttpPost]
        public async Task<IActionResult> edit(Vm_driver A) 
        {
             var q=db.Tbl_driver.Where(a=>a.Id.ToString()==User.Identity.GetId()).SingleOrDefault();
          if (A. img!=null)
          {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
                string FileExtension1 = Path.GetExtension(A. img.FileName);
                string  NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
                var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {

                    await A. img.CopyToAsync(stream);



                }
               
            q.NameFamily=A.NameFamily;
             q.Adress=A.Adress;
             q.profile_img =NewFileName; //////////////////////////end upload file
              
          }else
          {
              q.NameFamily=A.NameFamily;
             q.Adress=A.Adress;
            
          }
       
          
           
                
        

             db.Tbl_driver.Update(q);
            db.SaveChanges();
             

             ///name.photo.credit
            HttpContext.Session.SetString ("name",db.Tbl_driver.Where(a=>a.Id.ToString()==User.Identity.GetId())?.SingleOrDefault().NameFamily);
            HttpContext.Session.SetString ("photo",db.Tbl_driver.Where(a=>a.Id.ToString()==User.Identity.GetId())?.SingleOrDefault().profile_img);
             //

            return RedirectToAction("index");
        }
    }
}