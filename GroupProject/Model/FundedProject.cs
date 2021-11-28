using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Model
{
    public class FundedProject
    {
        public int Id { get; set; }
        public Backer Backer { get; set; }
        public List<Project> Projects { get; set; }

    }
}
