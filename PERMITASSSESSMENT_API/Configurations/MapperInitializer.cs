using AutoMapper;
using PERMITASSSESSMENT_API.Data;
using PERMITASSSESSMENT_API.Models;

namespace PERMITASSSESSMENT_API.Configurations
{
    public class MapperInitializer : Profile
    {

        public MapperInitializer()
        {
            CreateMap<Assessment_Detail,Assessment_DetailDTO>().ReverseMap();
            CreateMap<Assessment_Detail, CreateAssessment_DetailDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<ComputationStyle, ComputationSyleDTO>().ReverseMap();
            CreateMap<ComputationStyle, CreateComputationSyleDTO>().ReverseMap();
            CreateMap<Fee, FeeDTO>().ReverseMap();
            CreateMap<Fee, CreateFeeDTO>().ReverseMap();
            CreateMap<FeeComputation, FeeComputationDTO>().ReverseMap();
            CreateMap<FeeComputation, CreateFeeComputationDTO>().ReverseMap();
            CreateMap<OPFeeReference, OPFeeReferenceDTO>().ReverseMap();
            CreateMap<OPFeeReference, CreateOPFeeReferenceDTO>().ReverseMap();
            CreateMap<PermitType, PermitTypeDTO>().ReverseMap();
            CreateMap<PermitType, CreatePermitTypeDTO>().ReverseMap();
        }
    }
}
