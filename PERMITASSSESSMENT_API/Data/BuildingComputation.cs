using Microsoft.EntityFrameworkCore;

namespace PERMITASSSESSMENT_API.Data
{
    public class BuildingComputation
    {
        [Precision(18, 2)]
        public decimal? FloorArea { get; set; }
        [Precision(18, 2)]
        public decimal? Height { get; set; }
        [Precision(18, 2)]
        public decimal? LineGrade { get; set; }
        [Precision(18, 2)]
        public decimal? OtherSides { get; set; }
        [Precision(18, 2)]
        public decimal? ExcessHeight { get; set; }
        [Precision(18, 2)]
        public decimal? Additional { get; set; }
        [Precision(18, 2)]
        public string? ControlNum { get; set; }
        public int? CatID { get; set; }
        public string? Evaluator { get; set; }
        public string? ScopeofWork { get; set; }
        [Precision(18, 2)]
        public decimal? ProjectCost { get; set; }
        [Precision(18, 2)]
        public decimal? Excavation { get; set; }

    }
}
