using PERMITASSSESSMENT_API.Data;

namespace PERMITASSSESSMENT_API.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Assessment_Detail> Assessment_Details { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<ComputationStyle> ComputationStyles { get; }
        IGenericRepository<Fee> Fees { get; }
        IGenericRepository<FeeComputation> FeeComputations { get; }
        IGenericRepository<OPFeeReference> OPFeeReferences { get; }
        IGenericRepository<PermitType> PermitTypes { get; }

        Task Save();

        //Task Output(string storedProc);
    }
}
