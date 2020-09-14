using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabourReporting.Models
{
    public class OperatorWorkstation
    {
        public int OperatorID { get; set; }
        public Operator Operator { get; set; }
        public int WorkStationId { get; set; }
        public WorkStation WorkStation { get; set; }
    }
}
