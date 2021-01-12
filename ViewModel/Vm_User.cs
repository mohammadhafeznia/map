using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ViewModel
{
    public class Vm_User
    {
        [Key]
        public int Id { get; set; }
        public string NameFamily { get; set; }
        public string phone  { get; set; }
         public string Adress  { get; set; }
          public string Lat  { get; set; }
           public string Len  { get; set; }
           public string token { get; set; }
           public string photo { get; set; }
           public IFormFile  photos { get; set; }

           
           
           
           
           
        
        
        
    }
}