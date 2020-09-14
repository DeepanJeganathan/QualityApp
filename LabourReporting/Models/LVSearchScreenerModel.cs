using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabourReporting.Models
{
    public class LVSearchScreenerModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
          public DateTime? fromDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? toDate { get; set; }

        public decimal? valueMin { get; set; }
        public decimal? valueMax { get; set; }

        public string defect { get; set; }
    

    }
}
