using Microsoft.EntityFrameworkCore;
using PERMITASSSESSMENT_API.Data;
using PERMITASSSESSMENT_API.Models;

namespace PERMITASSSESSMENT_API.Models
{
    public class CreateAssessment_DetailDTO
    {
       
        public string? AssessedFees { get; set; }
        [Precision(18, 2)]
        public decimal? Amount { get; set; }
        public DateTime? DateAssessed { get; set; }
        public string? Assessed_By { get; set; }
        public string? Control_Num { get; set; }
        public int? RefID { get; set; }
        public int? FeeID { get; set; }

    }

    public class Assessment_DetailDTO : CreateAssessment_DetailDTO
    {
        public int Id { get; set; }
        public OPFeeReference? OPFeeReference { get; set; }
        public Fee? Fee { get; set; }
    }
    public class UpdateAssessment_DetailDTO : CreateAssessment_DetailDTO
    {

    }
}
