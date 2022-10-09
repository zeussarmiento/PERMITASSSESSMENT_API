using PERMITASSSESSMENT_API.Data;

namespace PERMITASSSESSMENT_API.Models
{
    public class CreateFeeDTO
    {
        public string? FeeDescription { get; set; }
        public bool? IsMandatory { get; set; }

        public int? PType { get; set; }
        
    }
    public class FeeDTO : CreateFeeDTO
    {
        public int FeeID { get; set; }
        public PermitType? PermitType { get; set; }
    }
    public class UpdateFeeDTO : CreateFeeDTO
    {

    }
}
