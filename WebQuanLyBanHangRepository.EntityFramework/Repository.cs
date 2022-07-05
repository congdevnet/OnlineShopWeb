using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebBanHang.Common;
using WebBanHangRepository;

namespace EPS.Utils.Repository.EntityFramework
{
    public class Repository<TContext> : IRepository
        where TContext : DbContext, new()
    {
        protected TContext _dbContext;
        protected bool _inBatchInsert = false;

        public Repository(TContext dbContext = null)
        {
            _dbContext = dbContext ?? new TContext();
        }

        public virtual IQueryable<TEntity> All<TEntity>()
            where TEntity : class
        {
            return _dbContext.Set<TEntity>();
        }

        public virtual int Count<TEntity>(params Expression<Func<TEntity, bool>>[] predicates)
            where TEntity : class
        {
            return _dbContext.Set<TEntity>()
                .WhereMany(predicates)
                .Count();
        }

        public virtual async Task<int> CountAsync<TEntity>(params Expression<Func<TEntity, bool>>[] predicates)
            where TEntity : class
        {
            return await _dbContext.Set<TEntity>()
                .WhereMany(predicates)
                .CountAsync();
        }

        public virtual TEntity Find<TEntity>(params Expression<Func<TEntity, bool>>[] predicates)
            where TEntity : class
        {
            return _dbContext.Set<TEntity>()
                .WhereMany(predicates)
                .FirstOrDefault();
        }

        public virtual TEntity Find<TEntity>(object id)
            where TEntity : class
        {
            if (id is object[])
            {
                return _dbContext.Set<TEntity>().Find(id as object[]);
            }
            else
            {
                return _dbContext.Set<TEntity>().Find(id);
            }
        }

        public virtual async Task<TEntity> FindAsync<TEntity>(params Expression<Func<TEntity, bool>>[] predicates)
            where TEntity : class
        {
            return await _dbContext.Set<TEntity>()
                .WhereMany(predicates)
                .FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> FindAsync<TEntity>(object id)
            where TEntity : class
        {
            if (id is object[])
            {
                return await _dbContext.Set<TEntity>().FindAsync(id as object[]);
            }
            else
            {
                return await _dbContext.Set<TEntity>().FindAsync(id);
            }
        }

        public virtual IQueryable<TEntity> Filter<TEntity>(params Expression<Func<TEntity, bool>>[] predicates)
            where TEntity : class
        {
            return _dbContext.Set<TEntity>()
                .WhereMany(predicates);
        }

        public virtual IQueryable<TEntity> FilterPaged<TEntity>(PagingParams<TEntity> pagingParams)
            where TEntity : class
        {
            if (pagingParams == null)
            {
                throw new ArgumentNullException("pagingParams");
            }

            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (pagingParams.Predicates != null)
            {
                query = query.WhereMany(pagingParams.Predicates.ToArray());
            }

            // Ordering
            if (pagingParams.SortExpression != null)
            {
                query = query.OrderBy(pagingParams.SortExpression);

                // Skipping only work after ordering
                if (pagingParams.StartingIndex > 0)
                {
                    query = query.Skip(pagingParams.StartingIndex);
                }
            }

            if (pagingParams.PageSize > 0)
            {
                query = query.Take(pagingParams.PageSize);
            }

            return query;
        }

        public virtual IQueryable<TEntity> FilterPaged<TEntity>(out int total, PagingParams<TEntity> pagingParams)
            where TEntity : class
        {
            if (pagingParams == null)
            {
                throw new ArgumentNullException("pagingParams");
            }

            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (pagingParams.Predicates != null)
            {
                query = query.WhereMany(pagingParams.Predicates.ToArray());
            }

            total = query.Count();

            // Ordering
            if (pagingParams.SortExpression != null)
            {
                query = query.OrderBy(pagingParams.SortExpression);

                // Skipping only work after ordering
                if (pagingParams.StartingIndex > 0)
                {
                    query = query.Skip(pagingParams.StartingIndex);
                }
            }

            if (pagingParams.PageSize > 0)
            {
                query = query.Take(pagingParams.PageSize);
            }

            return query;
        }

        public virtual PagingResult<TEntity> GetPaged<TEntity>(PagingParams<TEntity> pagingParams)
            where TEntity : class
        {
            if (pagingParams == null)
            {
                throw new ArgumentNullException("pagingParams");
            }

            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (pagingParams.Predicates != null)
            {
                query = query.WhereMany(pagingParams.Predicates.ToArray());
            }

            // Ordering
            if (pagingParams.SortExpression != null)
            {
                query = query.OrderBy(pagingParams.SortExpression);

                // Skipping only work after ordering
                if (pagingParams.StartingIndex > 0)
                {
                    query = query.Skip(pagingParams.StartingIndex);
                }
            }

            var total = query.Count();

            var result = new PagingResult<TEntity>();

            result.Items = query.Take(pagingParams.PageSize).ToList();
            result.Count = total;
            result.Page = pagingParams.Page;
            result.PageSize = pagingParams.PageSize;

            return result;
        }

        public bool Contain<TEntity>(params Expression<Func<TEntity, bool>>[] predicates)
            where TEntity : class
        {
            return _dbContext.Set<TEntity>().WhereMany(predicates).Any();
        }

        public async Task<bool> ContainAsync<TEntity>(params Expression<Func<TEntity, bool>>[] predicates)
            where TEntity : class
        {
            return await _dbContext.Set<TEntity>().WhereMany(predicates).AnyAsync();
        }

        public virtual void Create<TEntity>(params TEntity[] entities)
            where TEntity : class
        {
            foreach (var entity in entities)
            {
                _dbContext.Set<TEntity>().Add(entity);
            }
            if (!_inBatchInsert)
            {
                _dbContext.SaveChanges();
            }
        }

        public virtual async Task CreateAsync<TEntity>(params TEntity[] entities)
            where TEntity : class
        {
            foreach (var entity in entities)
            {
                _dbContext.Set<TEntity>().Add(entity);
            }
            await _dbContext.SaveChangesAsync();
        }

        public virtual int Delete<TEntity, TKey>(TKey id)
            where TEntity : class
        {
            var entity = Find<TEntity>(id);
            //if (entity is ICascadeDelete<TContext>)
            //{
            //    (entity as ICascadeDelete<TContext>).OnDelete(_dbContext);
            //}
            _dbContext.Set<TEntity>().Remove(entity);

            return _dbContext.SaveChanges();
        }

        public virtual int Delete<TEntity, TKey>(TKey[] ids)
            where TEntity : class
        {
            foreach (var id in ids)
            {
                var entity = Find<TEntity>(id);
                //if (entity is ICascadeDelete<TContext>)
                //{
                //    (entity as ICascadeDelete<TContext>).OnDelete(_dbContext);
                //}
                _dbContext.Set<TEntity>().Remove(entity);
            }

            return _dbContext.SaveChanges();
        }

        public virtual int Delete<TEntity>(TEntity entity)
            where TEntity : class
        {
            //if (entity is ICascadeDelete<TContext>)
            //{
            //    (entity as ICascadeDelete<TContext>).OnDelete(_dbContext);
            //}
            _dbContext.Set<TEntity>().Remove(entity);

            return _dbContext.SaveChanges();
        }

        public virtual int Delete<TEntity>(TEntity[] entities)
            where TEntity : class
        {
            foreach (var entity in entities)
            {
                //if (entity is ICascadeDelete<TContext>)
                //{
                //    (entity as ICascadeDelete<TContext>).OnDelete(_dbContext);
                //}
                _dbContext.Set<TEntity>().Remove(entity);
            }

            return _dbContext.SaveChanges();
        }

        public virtual int Delete<TEntity>(params Expression<Func<TEntity, bool>>[] predicates)
            where TEntity : class
        {
            var entiteis = Filter<TEntity>(predicates);
            foreach (var entity in entiteis)
            {
                //if (entity is ICascadeDelete<TContext>)
                //{
                //    (entity as ICascadeDelete<TContext>).OnDelete(_dbContext);
                //}
                _dbContext.Set<TEntity>().Remove(entity);
            }
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync<TEntity, TKey>(TKey id)
            where TEntity : class
        {
            var entity = await FindAsync<TEntity>(id);
            //if (entity is ICascadeDelete<TContext>)
            //{
            //    (entity as ICascadeDelete<TContext>).OnDelete(_dbContext);
            //}
            _dbContext.Set<TEntity>().Remove(entity);

            return await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync<TEntity, TKey>(TKey[] ids)
            where TEntity : class
        {
            foreach (var id in ids)
            {
                var entity = await FindAsync<TEntity>(id);
                //if (entity is ICascadeDelete<TContext>)
                //{
                //    (entity as ICascadeDelete<TContext>).OnDelete(_dbContext);
                //}
                _dbContext.Set<TEntity>().Remove(entity);
            }

            return await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            //if (entity is ICascadeDelete<TContext>)
            //{
            //    (entity as ICascadeDelete<TContext>).OnDelete(_dbContext);
            //}
            _dbContext.Set<TEntity>().Remove(entity);

            return await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync<TEntity>(TEntity[] entities)
            where TEntity : class
        {
            foreach (var entity in entities)
            {
                //if (entity is ICascadeDelete<TContext>)
                //{
                //    (entity as ICascadeDelete<TContext>).OnDelete(_dbContext);
                //}
                _dbContext.Set<TEntity>().Remove(entity);
            }

            return await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync<TEntity>(params Expression<Func<TEntity, bool>>[] predicates)
            where TEntity : class
        {
            var entities = Filter<TEntity>(predicates);
            foreach (var entity in entities)
            {
                //if (entity is ICascadeDelete<TContext>)
                //{
                //    (entity as ICascadeDelete<TContext>).OnDelete(_dbContext);
                //}
                _dbContext.Set<TEntity>().Remove(entity);
            }
            return await _dbContext.SaveChangesAsync();
        }

        public virtual int Update<TEntity>(params TEntity[] entities)
            where TEntity : class
        {
            foreach (var entity in entities)
            {
                var entry = _dbContext.Entry(entity);
            }
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> UpdateAsync<TEntity>(params TEntity[] entities)
            where TEntity : class
        {
            foreach (var entity in entities)
            {
                var entry = _dbContext.Entry(entity);
            }
            return await _dbContext.SaveChangesAsync();
        }

        public virtual void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public virtual async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public virtual int ExecuteNonQuery(string sql, params object[] sqlParams)
        {
            return _dbContext.Database.ExecuteSqlCommand(sql, sqlParams);
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
        }
    }
}