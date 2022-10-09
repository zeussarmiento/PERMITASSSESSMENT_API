using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PERMITASSSESSMENT_API.Data
{
    public class FeeComputation
    {
        [Key]
        public int FeeComputationID { get; set; }
       
        [Precision(18, 2)]
        public decimal? UpperBracket { get; set; }
        [Precision(18, 2)]
        public decimal? LowerBracket { get; set; }
        [Precision(18, 2)]
        public decimal? Amount { get; set; }
        [Precision(18, 2)]
        public decimal? Excess { get; set; }
        [Precision(18, 2)]
        public decimal? AdditionalAmount { get; set; }
        public int? FeeID { get; set; }
        [ForeignKey("FeeID")]
        public Fee? Fee { get; set; }
        public int? CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category? Category { get; set; }
        public int? CompStyleID { get; set; }
        [ForeignKey("CompStyleID")]
        public ComputationStyle? ComputationStyle { get; set; }
        [Precision(18, 2)]
        public decimal? ForEveryAmount { get; set; }




    }
}
