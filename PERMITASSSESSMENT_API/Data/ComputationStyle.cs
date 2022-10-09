using System.ComponentModel.DataAnnotations;

namespace PERMITASSSESSMENT_API.Data
{
    public class ComputationStyle
    {
        [Key]
        public int CompStyleID { get; set; }
        public string? Desciption { get; set; }

    }
}
