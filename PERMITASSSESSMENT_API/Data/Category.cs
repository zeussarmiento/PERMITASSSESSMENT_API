using System.ComponentModel.DataAnnotations;

namespace PERMITASSSESSMENT_API.Data
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string? Code { get; set; } 
        public string? Description { get; set; } 



    }
}
