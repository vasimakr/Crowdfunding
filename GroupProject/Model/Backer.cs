using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Model
{
    public class Backer : User
    {
        public List<FundedProject> FundedProjects { get; set; }


    }
}
