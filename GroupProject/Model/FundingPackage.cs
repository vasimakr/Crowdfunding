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
        [Required]
        public int Tier { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public string Description { get; set; }

        public virtual List<BackerPackage> BackerPackages { get; set; }

    }
}
