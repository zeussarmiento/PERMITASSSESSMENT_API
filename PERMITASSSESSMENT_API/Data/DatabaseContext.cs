using Microsoft.EntityFrameworkCore;

namespace PERMITASSSESSMENT_API.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<PermitType> PermitTypes => Set<PermitType>();
        public DbSet<ComputationStyle> ComputationStyles => Set<ComputationStyle>();
        public DbSet<Fee> Fees => Set<Fee>();
        public DbSet<FeeComputation> FeeComputations => Set<FeeComputation>();
        public DbSet<OPFeeReference> OPFeeReferences => Set<OPFeeReference>();
        public DbSet<Assessment_Detail> Assessment_Details => Set<Assessment_Detail>();



    }
}
