using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> AsQueryable();
        IEnumerable<T> QueryAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T GetOne(Expression<Func<T, bool>> predicate);
        T GetOneById(int Id);

        void Add(T entidad);
        void Modify(T entidad);
        void Delete(T entidad);

        void Save();
    }
}
