using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Model

{
    public class Backer : User
    {
        [Key]
        public int Id { get; set; }
        [InverseProperty("Backer")]
        public virtual List<BackerPackage> BackerPackages { get; set; }


    }
}
