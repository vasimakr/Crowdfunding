using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Model

{
    public class FundRaiserContext  : DbContext 
    {
        public DbSet<Backer> Backers { get; set; }

        public DbSet<Creator> Creators { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<FundingPackage> FundingPackages { get; set; }
        public DbSet<BackerPackage> BackerPackages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Crowdfunding;Integrated Security=True");
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Crowdfunding;User =sa;Password=admin!@#123");  //works for Vasili
            //optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Crowdfunding;User ID=sa;Password=admin!@#123");  //works for Ntina
            //optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Crowdfunding;User ID=sa;Password=admin!@#123");  //works for Mike
            //optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Crowdfunding;User ID=sa;Password=admin!@123");    //works for Nikita
        }

        
    }
}



        

