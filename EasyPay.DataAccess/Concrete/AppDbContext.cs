using EasyPay.Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay.DataAccess.Concrete
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        //public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}


        DbSet<CustomerAccount> CustomerAccounts { get; set; }
        DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-QNVH4DF; " +
                "initial catalog=EasyPayDb; integrated security=true");
        }

    }
}
