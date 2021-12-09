using Crowdfunding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingMvc.Models
{
    public class ProjectFunding
    {
        public Project Project { get; set; }
        public List<FundingPackage> FundingPackages { get; set; }
    }
}
