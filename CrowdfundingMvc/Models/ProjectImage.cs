using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crowdfunding.Model;
using Microsoft.AspNetCore.Http;


namespace CrowdfundingMvc.Models
{
    public class ProjectImage
    {
        public Project Project { get; set; }
        public int projId { get; set; }
        public IFormFile ProjectImageFile { get; set;  }
        public FundingPackage FundingPackage { get; set; }
    }
}
