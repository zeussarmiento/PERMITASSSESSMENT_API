namespace PERMITASSSESSMENT_API.Models
{
    public class CreateOPFeeReferenceDTO
    {
        public string? FeeDescription { get; set; }
        public string? AccountCode { get; set; }
        public string? SubsidiaryCode { get; set; }
        public string? DboCode { get; set; }
        public string? CtrlCode { get; set; }
        public string? IncomeClass { get; set; }
        public string? Fund { get; set; }
        public string? FundGroup { get; set; }
        public string? FundSubgroup { get; set; }
        public string? IncomeGroup { get; set; }
        public string? IncomeSubgroup { get; set; }
        public string? IncomeObject { get; set; }
        public string? IncomeTitle { get; set; }
        public string? BlgfCode { get; set; }
        public string? IncomeDesc { get; set; }
        public string? IncomeSubdesc { get; set; }
        public string? FormType { get; set; }
    }
    public class OPFeeReferenceDTO : CreateOPFeeReferenceDTO
    {
        public int ReferenceID { get; set; }
    }
    public class UpdateOPFeeReferenceDTO : CreateOPFeeReferenceDTO
    {

    }
}
