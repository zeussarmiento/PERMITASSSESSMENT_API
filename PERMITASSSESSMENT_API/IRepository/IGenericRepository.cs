﻿using System.Linq.Expressions;

namespace PERMITASSSESSMENT_API.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAll(
            Expression<Func<T,bool>>? expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
            List<string>? includes = null
            
            );

        Task<T> Get(Expression<Func<T, bool>> expression, List<string>? includes = null);

        Task Insert(T entity);

        Task InsertRange(IEnumerable<T> entities);

        Task Delete(int id);
        void DeleteRange(IEnumerable<T> entities);  

        void Update(T entity);

        Task Output(string storedProc);
    }
}
