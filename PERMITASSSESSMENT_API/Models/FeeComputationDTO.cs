using Microsoft.EntityFrameworkCore;
using PERMITASSSESSMENT_API.Data;

namespace PERMITASSSESSMENT_API.Models
{
    public class CreateFeeComputationDTO
    {
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
        public int? CatID { get; set; }
        public int? CompStyleID { get; set; }
        [Precision(18, 2)]
        public decimal? ForEveryAmount { get; set; }

    }
    public class FeeComputationDTO : CreateFeeComputationDTO
    {
        public int FeeComputationID { get; set; }
        public Fee? Fee { get; set; }
        public Category? Category { get; set; }
        public ComputationStyle? ComputationStyle { get; set; }
    }
    public class UpdateFeeComputationDTO : CreateFeeComputationDTO
    {

    }
}
