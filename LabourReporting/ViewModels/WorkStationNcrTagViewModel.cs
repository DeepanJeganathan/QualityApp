using LabourReporting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabourReporting.ViewModels
{
    public class WorkStationNcrTagViewModel
    {
        public IEnumerable<NcrTag> NcrTags { get; set; }
        public IEnumerable<WorkStation> WorkStations { get; set; }

        public IEnumerable<FtBreakdown> FtBreakdowns { get; set; }

    }
}
