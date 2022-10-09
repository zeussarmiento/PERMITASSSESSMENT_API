using Microsoft.EntityFrameworkCore;
using PERMITASSSESSMENT_API.Data;
using PERMITASSSESSMENT_API.IRepository;
using System.Linq.Expressions;

namespace PERMITASSSESSMENT_API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
#pragma warning disable CS8604 // Possible null reference argument.
            _db.Remove(entity);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string>? includes = null)
        {
            IQueryable<T> query = _db;
            if (includes != null)
            {
                foreach (var includeproperty in includes)
                    query = query.Include(includeproperty); 
            }

#pragma warning disable CS8603 // Possible null reference return.
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null, List<string>? includes = null)
        {
            IQueryable<T> query = _db;

            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                foreach (var includeproperty in includes)
                    query = query.Include(includeproperty);
            }

            if (orderby != null)
            {
                query = orderby(query);
            }

#pragma warning disable CS8603 // Possible null reference return.
            return await query.AsNoTracking().ToListAsync();
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public Task Output(string storedProc) => _context.Assessment_Details.FromSqlRaw(storedProc).ToListAsync();

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

    }
}
