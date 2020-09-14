using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabourReporting.Models
{
    public class NcrTag
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public double Tag_No { get; set; }        
        
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date_Rej { get; set; }

        [Required]
        public string Disposition { get; set; }
        [Required]
        public string Item { get; set; }
        
        public string Colour { get; set; }
    
        public int? Put_Up { get; set; }
        [Required]
        public double   Qty { get; set; }

        public int? Order_number { get; set; }

        public string Defect { get; set; }      

        public string NcrComments { get; set; }

        public string SupervisorSignature { get; set; }

        public int? OperationNumber { get; set; }

        //operator table Fk 
        public int? OperatorId { get; set; }

        public Operator Operator { get; set; }

        //fk workstation table
        public int? WorkStationId { get; set; }
        public WorkStation WorkStation { get; set; }

     



    }
}
