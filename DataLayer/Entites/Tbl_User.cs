using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entites
{
    public class Tbl_User
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
           
           
           
           
           
        
        
        
    }
}