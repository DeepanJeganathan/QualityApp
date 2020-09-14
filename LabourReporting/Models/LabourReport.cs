using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabourReporting.Models
{
    public class LabourReport
    {
        public int LabourReportId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required]
        [RegularExpression(@"[0-9]{6}",ErrorMessage ="Shop order must be 8 digits")]
        public int ShopOrder { get; set; }
        [Required]
        public string ItemNo { get; set; }
      
        [Required]
        [Range(0,100,ErrorMessage ="Hours cannot be over 100")]
        public float AllowedTime { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "Hours cannot be over 100")]
        public float TotalTime { get; set; }
        [Required]
        public double Quantity { get; set; }

        public double? Scrap { get; set; }
        
        public string Comments { get; set; }

        public string SupervisorComments { get; set; }

        //fk operator
       [Required]
        [RegularExpression(@"[0-9]{4}", ErrorMessage = "Employee number must be 4 digits")]
        public int OperatorID { get; set; }

        public Operator Operators { get; set; }

    }
}
