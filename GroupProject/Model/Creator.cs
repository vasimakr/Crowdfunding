using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Model

{
    public class Creator : User
    {
        public List<Project> OwnedProjects { get; set; }
    }
}
