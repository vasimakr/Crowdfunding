﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Crowdfunding.Model
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string StatusUpdate { get; set; } 
        public Category Category { get; set; }
        public virtual List<FundingPackage> FundingPackages { get; set; }
        public bool IsTrending { get; set; }
        public int Fundings { get; set; } = 0;
        [Required]
        public int Goal { get; set; }

        [ForeignKey("CreatorId")]
        public Creator Creator { get; set; }
    }
}
