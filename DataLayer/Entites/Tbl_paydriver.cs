using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entites
{
    public class Tbl_paydriver
    {
            [Key]
         public int Id { get; set; }
         public string Driverid{ get; set; }
        public string Travelid{ get; set; }
         public string NameFamily { get; set; }
          public int Pay { get; set; }
        public int Harvest { get; set; }
         public DateTime Paytime { get; set; }
         public DateTime havesttime { get; set; }
         public string status { get; set; }
         
    }
}