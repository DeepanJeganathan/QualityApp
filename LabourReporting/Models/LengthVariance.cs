using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabourReporting.Models
{
    public class LengthVariance
    {
        public int LengthVarianceID { get; set; }        

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

       [Required]
        public string Item { get; set; }
        
        [Required]
        public double Qty { get; set; }

        public string UOM { get; set; }

        public int? Order_number { get; set; }

        public double? LotNo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }

        public int Cell { get; set; }


        public string DefectCode { get; set; }

        public string Comments { get; set; }
        //fk
        public int WorkStationId { get; set; }
        //nav
        public WorkStation WorkStation { get; set; }


    }
}
