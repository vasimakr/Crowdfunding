using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StatusUpdate { get; set; } //List
        public Category Category { get; set; }
        public virtual List<ProjectReward> ProjectRewards { get; set; }
        public bool IsTrending { get; set; }
        public int Fundings { get; set; }
        public int Goal { get; set; }

        [ForeignKey("CreatorId")]
        public Creator Creator { get; set; }
    }
}
