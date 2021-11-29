using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Model
{

    public class FundingPackage
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public int Tier { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
