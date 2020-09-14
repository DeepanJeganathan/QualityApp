using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabourReporting.Models
{
    public class FtBreakdown
    {
        [Key]
        public int FtBreakdownId { get; set; }

        public double Ncr_No { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        public string Comments { get; set; }

        public string RootCause { get; set; }

        public string SecondLevel { get; set; }

        public string Compound { get; set; }

        public int AWGSize { get; set; }

        
    }
}
