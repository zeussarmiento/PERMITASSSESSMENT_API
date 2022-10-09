namespace PERMITASSSESSMENT_API.Models
{
    public class CreateCategoryDTO
    {
        public string? Code { get; set; }
        public string? Description { get; set; }

    }

    public class CategoryDTO : CreateCategoryDTO
    {
        public int CategoryID { get; set; }
    }
    public class UpdateCategoryDTO : CreateCategoryDTO
    {
       
    }
}
