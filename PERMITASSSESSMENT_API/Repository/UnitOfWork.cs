using Microsoft.EntityFrameworkCore;
using PERMITASSSESSMENT_API.Data;
using PERMITASSSESSMENT_API.IRepository;

namespace PERMITASSSESSMENT_API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private  IGenericRepository<Assessment_Detail> _Assessment_Details;
        private  IGenericRepository<Category> _Categories;
        private  IGenericRepository<ComputationStyle> _ComputationStyles;
        private  IGenericRepository<Fee> _Fees;
        private  IGenericRepository<FeeComputation> _FeeComputations;
        private  IGenericRepository<OPFeeReference> _OPFeeReferences;
        private  IGenericRepository<PermitType> _PermitTypes;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public UnitOfWork(DatabaseContext context)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _context = context;
        }

        public IGenericRepository<Assessment_Detail> Assessment_Details => _Assessment_Details ??= new GenericRepository<Assessment_Detail>(_context);

        public IGenericRepository<Category> Categories => _Categories ??= new GenericRepository<Category>(_context);

        public IGenericRepository<ComputationStyle> ComputationStyles => _ComputationStyles ??= new GenericRepository<ComputationStyle>(_context);

        public IGenericRepository<Fee> Fees => _Fees ??= new GenericRepository<Fee>(_context);

        public IGenericRepository<FeeComputation> FeeComputations => _FeeComputations ??= new GenericRepository<FeeComputation>(_context);

        public IGenericRepository<OPFeeReference> OPFeeReferences => _OPFeeReferences ??= new GenericRepository<OPFeeReference>(_context);

        public IGenericRepository<PermitType> PermitTypes => _PermitTypes ??= new GenericRepository<PermitType>(_context);

        public void Dispose()
        {
           _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        //public async Task Output(string storedproc)
        //{
        //    await _context.Assessment_Details.FromSqlRaw(storedproc).ToListAsync();

        //}
    }
}
