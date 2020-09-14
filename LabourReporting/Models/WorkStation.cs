using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabourReporting.Models
{
    public enum Department
    {
        Flow_1=1,
        Flow_2,
        Flow_3,
        Flow_4,
        

    }
    public class WorkStation

    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkStationId { get; set; }

        [Required]
        public string WorkStationName { get; set; }

        [Required]
        public Department Department { get; set; }

        public ICollection<NcrTag> NcrTags { get; set; }

       public ICollection<OperatorWorkstation> OperatorWorkstations { get; set; }

        public ICollection<LengthVariance> LengthVariances { get; set; }


    }
}
