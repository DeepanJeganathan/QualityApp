using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabourReporting.Models;

namespace LabourReporting.ViewModels
{
    public class WorkstationOperatorNcrtagViewModel
    {
        public IEnumerable<WorkStation> WorkStations { get; set; }

        public IEnumerable<OperatorWorkstation> OperatorWorkstations { get; set; }
        public IEnumerable<Operator> Operators { get; set; }

        public IEnumerable<NcrTag> NcrTags { get; set; }

    }
}
