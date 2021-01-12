using System.ComponentModel.DataAnnotations;
using System;
namespace ViewModel
{
    public class Vm_Travel
    {
        
        [Key]
        public int Id { get; set; }
        public string UserPhone { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Distance { get; set; }
        public string Price { get; set; }
         public string Time { get; set; }
        public DateTime DateDay { get; set; }
        public int DriverId { get; set; }
        public string TypePay { get; set; }
    }
}