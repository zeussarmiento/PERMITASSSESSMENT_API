namespace PERMITASSSESSMENT_API.Models
{
    public class CreateComputationSyleDTO
    {
        public string? Desciption { get; set; }
    }

    public class ComputationSyleDTO : CreateComputationSyleDTO
    {
        public int CompStyleID { get; set; }
    }
    public class UpdateComputationSyleDTO : CreateComputationSyleDTO
    {

    }
}
