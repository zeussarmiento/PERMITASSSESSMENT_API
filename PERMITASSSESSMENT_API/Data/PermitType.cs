using System.ComponentModel.DataAnnotations;

namespace PERMITASSSESSMENT_API.Data
{
    public class PermitType
    {
        [Key]
        public int PtypeID { get; set; }
        public string? Description { get; set; }    
    }
}
