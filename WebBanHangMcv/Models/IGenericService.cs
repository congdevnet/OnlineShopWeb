using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebBanHangMcv.Models
{
    public interface IGenericService<TEntity> : IBaseService
         where TEntity : class
    {
        IQueryable<TDto> All<TDto>();

        int Count<TDto>(params Expression<Func<TDto, bool>>[] predicates);

        Task<int> CountAsync<TDto>(params Expression<Func<TDto, bool>>[] predicates);

        TDto Find<TDto>(params Expression<Func<TDto, bool>>[] predicates);

        TDto Find<TDto>(object id);

        Task<TDto> FindAsync<TDto>(object id);

        Task<TDto> FindAsync<TDto>(params Expression<Func<TDto, bool>>[] predicates);

        IQueryable<TDto> Filter<TDto>(params Expression<Func<TDto, bool>>[] predicates);

        bool Contain<TDto>(params Expression<Func<TDto, bool>>[] predicates);

        Task<bool> ContainAsync<TDto>(params Expression<Func<TDto, bool>>[] predicates);

        void Create<TDto>(params TDto[] dtos) where TDto : class;

        Task CreateAsync<TDto>(params TDto[] dtos) where TDto : class;

        int Delete<TKey>(TKey id);

        int Delete<TKey>(TKey[] ids);

        int Delete<TDto>(params Expression<Func<TDto, bool>>[] predicates);

        Task<int> DeleteAsync<TKey>(TKey id);

        Task<int> DeleteAsync<TKey>(params TKey[] ids);

        Task<int> DeleteAsync<TDto>(params Expression<Func<TDto, bool>>[] predicates);

        int Update<TDto>(TDto dto, object id) where TDto : class;

        Task<int> UpdateAsync<TDto>(TDto dto, object id) where TDto : class;
    }
}