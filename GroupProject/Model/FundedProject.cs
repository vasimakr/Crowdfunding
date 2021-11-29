﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Model
{
    public class FundedProject
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("BackerId")]
        public Backer Backer { get; set; }
        //[InverseProperty("Backer")]
        public virtual List<FundedProject> FundedProjects { get; set; }

    }
}
