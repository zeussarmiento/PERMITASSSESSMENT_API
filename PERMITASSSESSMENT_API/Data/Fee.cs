using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PERMITASSSESSMENT_API.Data
{
    public class Fee
    {
        [Key]
        public int FeeID { get; set; }

        public string? FeeDescription { get; set; }
        public bool? IsMandatory { get; set; }

        public int? PtypeID { get; set; }
        [ForeignKey("PtypeID")]
        public PermitType? PermitType { get; set; }


    }
}
