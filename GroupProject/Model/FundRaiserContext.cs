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
    }
}
