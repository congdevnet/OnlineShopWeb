using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebBanHangMcv.Models
{
    public interface IBaseService : IDisposable
    {
        IQueryable<TDto> All<TEntity, TDto>()
            where TEntity : class;

        int Count<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        Task<int> CountAsync<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        TDto Find<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        TDto Find<TEntity, TDto>(object id)
            where TEntity : class;

        Task<TDto> FindAsync<TEntity, TDto>(object id)
            where TEntity : class;

        Task<TDto> FindAsync<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        IQueryable<TDto> Filter<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        //IQueryable<TDto> FilterPaged<TEntity, TDto>(PagingParams<TEntity, TDto> pagingParams)
        //    where TEntity : class;

        //IQueryable<TDto> FilterPaged<TEntity, TDto>(out int total, PagingParams<TEntity, TDto> pagingParams)
        //    where TEntity : class;

        //PagingResult<TDto> GetPaged<TEntity, TDto>(PagingParams<TEntity, TDto> pagingParams)
        //    where TEntity : class
        //    where TDto : class;

        //Task<PagingResult<TDto>> GetPagedAsync<TEntity, TDto>(PagingParams<TEntity, TDto> pagingParams)
        //    where TEntity : class
        //    where TDto : class;

        bool Contain<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        Task<bool> ContainAsync<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        void Create<TEntity, TDto>(params TDto[] dtos)
            where TEntity : class
            where TDto : class;

        Task CreateAsync<TEntity, TDto>(params TDto[] dtos)
            where TEntity : class
            where TDto : class;

        int Delete<TEntity, TKey>(TKey id)
            where TEntity : class;

        int Delete<TEntity, TKey>(TKey[] ids)
            where TEntity : class;

        int Delete<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        Task<int> DeleteAsync<TEntity, TKey>(TKey id)
            where TEntity : class;

        Task<int> DeleteAsync<TEntity, TKey>(TKey[] ids)
            where TEntity : class;

        Task<int> DeleteAsync<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        int Update<TEntity, TDto>(TDto dto, object id)
            where TEntity : class
            where TDto : class;

        Task<int> UpdateAsync<TEntity, TDto>(TDto dto, object id)
            where TEntity : class
            where TDto : class;

        int ExecuteNonQuery(string sql, params object[] sqlParams);
    }
}