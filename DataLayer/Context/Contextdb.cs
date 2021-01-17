using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DataLayer.Entites;
using DataLayer.Context;

namespace DataLayer.Context
{
    public class Contextdb:DbContext
    {
         public Contextdb(DbContextOptions<Contextdb> options) : base(options)
        {

        }

      public  DbSet<Tbl_User> tbl_Users{get; set;}
    public  DbSet<Tbl_Travel> tbl_Travels{get; set;}
      public  DbSet<Tbl_driver> Tbl_driver{get; set;}
     public  DbSet<Tbl_pay> Tbl_pays{get; set;}
      public  DbSet<Tbl_paydriver> Tbl_paydriver{get; set;}

 /////////////////////////////////////////////////////////////////////////////////////copy context
  public class ToDoContextFactory : IDesignTimeDbContextFactory<Contextdb>
    {
        public Contextdb CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Contextdb>();
            //   builder.UseSqlServer("Data Source=.;initial Catalog=monojobs;integrated Security=SSPI;MultipleActiveResultSets=true");
            builder.UseSqlServer("Data Source=.;initial Catalog=map;integrated Security=SSPI;MultipleActiveResultSets=true");
            return new Contextdb(builder.Options);
        }
    }
/////////
        
    }
}