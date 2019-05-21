using AddressApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressApp.Repository.DBContext
{
    public class AddressDBEntities: DbContext
    {
        public AddressDBEntities() : base("name=AddressDBEntities")
        {
        }
        public  DbSet<AddressBook> AddressBooks { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<AddressDBEntities>(null);
        //    base.OnModelCreating(modelBuilder);
        //}
       
    }
}
