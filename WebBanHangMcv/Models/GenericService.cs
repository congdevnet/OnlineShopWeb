using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanHangMcv.Models
{
    public class GenericService<TEntity> : BaseService, IGenericService<TEntity>
         where TEntity : class
    {
        public GenericService(IRepository repository)
            : base(repository) { }
        public virtual IQueryable<TDto> All<TDto>()
        {
            return base.All<TEntity, TDto>();
        }

        public virtual int Count<TDto>(params System.Linq.Expressions.Expression<Func<TDto, bool>>[] predicates)
        {
            return base.Count<TEntity, TDto>(predicates);
        }

        public virtual async Task<int> CountAsync<TDto>(params System.Linq.Expressions.Expression<Func<TDto, bool>>[] predicates)
        {
            return await base.CountAsync<TEntity, TDto>(predicates);
        }

        public virtual TDto Find<TDto>(params System.Linq.Expressions.Expression<Func<TDto, bool>>[] predicates)
        {
            return base.Find<TEntity, TDto>(predicates);
        }

        public virtual TDto Find<TDto>(object id)
        {
            return base.Find<TEntity, TDto>(id);
        }

        public virtual async Task<TDto> FindAsync<TDto>(object id)
        {
            return await base.FindAsync<TEntity, TDto>(id);
        }

        public virtual async Task<TDto> FindAsync<TDto>(params System.Linq.Expressions.Expression<Func<TDto, bool>>[] predicates)
        {
            return await base.FindAsync<TEntity, TDto>(predicates);
        }

        public virtual IQueryable<TDto> Filter<TDto>(params System.Linq.Expressions.Expression<Func<TDto, bool>>[] predicates)
        {
            return base.Filter<TEntity, TDto>(predicates);
        }
        public virtual bool Contain<TDto>(params System.Linq.Expressions.Expression<Func<TDto, bool>>[] predicates)
        {
            return base.Contain<TEntity, TDto>(predicates);
        }

        public virtual async Task<bool> ContainAsync<TDto>(params System.Linq.Expressions.Expression<Func<TDto, bool>>[] predicates)
        {
            return await base.ContainAsync<TEntity, TDto>(predicates);
        }

        public virtual void Create<TDto>(params TDto[] dtos) where TDto : class
        {
            base.Create<TEntity, TDto>(dtos);
        }

        public virtual async Task CreateAsync<TDto>(params TDto[] dtos) where TDto : class
        {
            await base.CreateAsync<TEntity, TDto>(dtos);
        }

        public virtual int Delete<TKey>(TKey id)
        {
            return base.Delete<TEntity, TKey>(id);
        }

        public virtual int Delete<TKey>(TKey[] ids)
        {
            return base.Delete<TEntity, TKey>(ids);
        }

        public virtual int Delete<TDto>(params System.Linq.Expressions.Expression<Func<TDto, bool>>[] predicates)
        {
            return base.Delete<TEntity, TDto>(predicates);
        }

        public virtual async Task<int> DeleteAsync<TKey>(TKey id)
        {
            return await base.DeleteAsync<TEntity, TKey>(id);
        }

        public virtual async Task<int> DeleteAsync<TKey>(TKey[] ids)
        {
            return await base.DeleteAsync<TEntity, TKey>(ids);
        }

        public virtual async Task<int> DeleteAsync<TDto>(params System.Linq.Expressions.Expression<Func<TDto, bool>>[] predicates)
        {
            return await base.DeleteAsync<TEntity, TDto>(predicates);
        }

        public virtual int Update<TDto>(TDto dto, object id) where TDto : class
        {
            return base.Update<TEntity, TDto>(dto, id);
        }

        public virtual async Task<int> UpdateAsync<TDto>(TDto dto, object id) where TDto : class
        {
            return await base.UpdateAsync<TEntity, TDto>(dto, id);
        }

    }
}