using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PERMITASSSESSMENT_API.Data
{
    public class Assessment_Detail
    {
        [Key]
        public int Id { get; set; }
        public string? AssessedFees { get; set; }
        [Precision(18, 2)]
        public decimal? Amount { get; set; }
        public DateTime? DateAssessed { get; set; }
        public string? Assessed_By { get; set; }
        public string? Control_Num { get; set; }
        public int? ReferenceID { get; set; }
        [ForeignKey("ReferenceID")]
        public OPFeeReference? OPFeeReference { get; set; }
        public int? FeeID { get; set; }
        [ForeignKey("FeeID")]
        public Fee? Fee { get; set; }



    }
}
