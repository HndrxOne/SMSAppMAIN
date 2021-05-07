using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext contexto)
        {
            contexto.Configuration.LazyLoadingEnabled = false;
            _context = contexto;
        }

        public IQueryable<T> AsQueryable()
        {
            return _context.Set<T>().AsNoTracking().AsQueryable();
        }

        public IEnumerable<T> QueryAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicado)
        {
            return _context.Set<T>().AsNoTracking().Where(predicado);
        }

        public T GetOne(Expression<Func<T, bool>> predicado)
        {
            return _context.Set<T>().AsNoTracking().Where(predicado).FirstOrDefault();
        }

        public T GetOneById(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public void Add(T entidad)
        {
            //if (_context.Entry<T>(entidad).State != EntityState.Detached)
            //    _context.Entry<T>(entidad).State = EntityState.Added;
            //else
            _context.Set<T>().Add(entidad);
        }

        public void Add(IEnumerable<T> entidad)
        {
            foreach (var Item in entidad)
            {
                Add(Item);
            }
        }

        public void Modify(T entidad)
        {
            //if (_context.Entry<T>(entidad).State == EntityState.Detached)
            //    _context.Set<T>().Attach(entidad);
            //else
            //     _context.Entry<T>(entidad).State = EntityState.Modified;         
            _context.Entry<T>(entidad).State = EntityState.Modified;

        }

        public void Modify(IEnumerable<T> entidad)
        {
            foreach (var Item in entidad)
            {
                Modify(Item);
            }

        }

        public void Delete(T entidad)
        {
            //if (_context.Entry<T>(entidad).State == EntityState.Detached)
            //    _context.Set<T>().Attach(entidad);
            //else
            //_context.Entry<T>(entidad).State = EntityState.Deleted;
            _context.Entry<T>(entidad).State = EntityState.Deleted;
        }

        public void Delete(IEnumerable<T> entidad)
        {
            foreach (var Item in entidad)
            {
                Delete(Item);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            return;
        }

        public IEnumerable<T> ExecuteReader(string storedProcedureName, SqlParameter[] parameters = null)
        {
            if (parameters != null && parameters.Any())
            {
                var parameterBuilder = new StringBuilder();
                parameterBuilder.Append(string.Format("{0} ", storedProcedureName));

                for (int i = 0; i < parameters.Length; i++)
                {
                    parameterBuilder.Append(string.Format("{0},", parameters[i].ParameterName));
                }

                var query = parameterBuilder.ToString().Substring(0, parameterBuilder.ToString().Length - 1);
                var result = _context.Database.SqlQuery<T>(query, parameters).ToList();
                return result;
            }
            else
            {
                var result = _context.Database.SqlQuery<T>(string.Format("EXEC {0}", storedProcedureName)).ToList();
                return result;
            }
        }

        public void ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            if (_context.Database.Connection.State == ConnectionState.Closed)
            {
                _context.Database.Connection.Open();
            }

            var command = _context.Database.Connection.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            command.ExecuteNonQuery();
        }
    }
}
