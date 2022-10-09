namespace PERMITASSSESSMENT_API.Models
{
    public class CreatePermitTypeDTO
    {
        public string? Description { get; set; }
    }
    public class PermitTypeDTO : CreatePermitTypeDTO
    {
        public int PtypeID { get; set; }
    }
    public class UpdatePermitTypeDTO : CreatePermitTypeDTO
    {

    }
}
