using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabourReporting.Models
{
    public class Operator
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OperatorID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<LabourReport> LabourReports { get; set; }


        //nav property operator-ncrtag
        public ICollection<NcrTag> NcrTags { get; set; }


        //operator-workstation join table nav property
        public ICollection<OperatorWorkstation> OperatorWorkstations { get; set; }
    }
}
