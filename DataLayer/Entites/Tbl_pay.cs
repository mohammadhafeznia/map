using System;
using System.ComponentModel.DataAnnotations;
namespace DataLayer.Entites
{
    public class Tbl_pay
    {
          [Key]
         public int Id { get; set; }
         public string Phone{ get; set; }
         public string NameFamily { get; set; }
          public int Pay { get; set; }
          public int Harvest { get; set; }
         public DateTime Paytime { get; set; }
         public DateTime havesttime { get; set; }
         public bool status { get; set; }
        public int idtravel { get; set; }
        
        
         
         
         
    
    
    }
}