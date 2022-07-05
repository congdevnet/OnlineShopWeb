using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace WebBanHangMcv.Models
{
    public class BaseService : IBaseService
    {
        protected IRepository _repository;

        public BaseService(IRepository repository)
        {
            _repository = repository;
        }
        public virtual IQueryable<TDto> All<TEntity, TDto>()
             where TEntity : class
        {
            return _repository.All<TEntity>().Project().To<TDto>();
        }

        public virtual int Count<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class
        {
            return _repository.Count<TEntity>(GetPredicates<TEntity, TDto>(predicates));
        }

        public virtual async Task<int> CountAsync<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class
        {
            return await _repository.CountAsync<TEntity>(GetPredicates<TEntity, TDto>(predicates));
        }

        public virtual TDto Find<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class
        {
            return Mapper.Map<TEntity, TDto>(_repository.Find<TEntity>(GetPredicates<TEntity, TDto>(predicates)));
        }

        public virtual TDto Find<TEntity, TDto>(object id)
            where TEntity : class
        {
            var entity = _repository.Find<TEntity>(id);
            var dto = Mapper.Map<TEntity, TDto>(entity);
            return dto;
        }

        public virtual async Task<TDto> FindAsync<TEntity, TDto>(object id)
            where TEntity : class
        {
            return Mapper.Map<TEntity, TDto>(await _repository.FindAsync<TEntity>(id));
        }

        public virtual async Task<TDto> FindAsync<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class
        {
            return Mapper.Map<TEntity, TDto>(await _repository.FindAsync<TEntity>(GetPredicates<TEntity, TDto>(predicates)));
        }

        public virtual IQueryable<TDto> Filter<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class
        {
            return _repository.Filter<TEntity>().Project().To<TDto>().WhereMany(predicates);
        }

        public virtual IQueryable<TDto> FilterPaged<TEntity, TDto>(PagingParams<TEntity, TDto> pagingParams)
            where TEntity : class
        {
            if (pagingParams == null)
            {
                throw new ArgumentNullException("pagingParams");
            }

            IQueryable<TDto> query = _repository.Filter<TEntity>().Project().To<TDto>();

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

            return query.AsQueryable();

            //return _repository.FilterPaged<TEntity>(ToRepoParams(pagingParams)).Project().To<TDto>();
        }

     

      
        public virtual bool Contain<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class
        {
            return _repository.Contain<TEntity>(GetPredicates<TEntity, TDto>(predicates));
        }

        public virtual async Task<bool> ContainAsync<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class
        {
            return await _repository.ContainAsync<TEntity>(GetPredicates<TEntity, TDto>(predicates));
        }

        public virtual void Create<TEntity, TDto>(params TDto[] dtos)
            where TEntity : class
            where TDto : class
        {
            var entities = Mapper.Map<TDto[], TEntity[]>(dtos);

            _repository.Create<TEntity>(entities);

            //if (dtos[0].IsDerivedFromGenericInterface(typeof(IIdentifier<>)) && entities[0].IsDerivedFromGenericInterface(typeof(IIdentifier<>)))
            //{
            //    for (var i = 0; i < entities.Length; i++)
            //    {
            //        dtos[i].SetProperty("Id", entities[i].GetProperty("Id"));
            //    }
            //}

            if (Mapper.FindTypeMapFor<TEntity, TDto>() != null)
            {
                for (var i = 0; i < entities.Length; i++)
                {
                    Mapper.Map(entities[i], dtos[i]);
                }
            }
        }

        public virtual async Task CreateAsync<TEntity, TDto>(params TDto[] dtos)
            where TEntity : class
            where TDto : class
        {
            var entities = Mapper.Map<TDto[], TEntity[]>(dtos);

            await _repository.CreateAsync<TEntity>(entities);

            //if (dtos[0].IsDerivedFromGenericInterface(typeof(IIdentifier<>)) && entities[0].IsDerivedFromGenericInterface(typeof(IIdentifier<>)))
            //{
            //    for (var i = 0; i < entities.Length; i++)
            //    {
            //        dtos[i].SetProperty("Id", entities[i].GetProperty("Id"));
            //    }
            //}

            if (Mapper.FindTypeMapFor<TEntity, TDto>() != null)
            {
                for (var i = 0; i < entities.Length; i++)
                {
                    Mapper.Map(entities[i], dtos[i]);
                }
            }
        }

        public virtual int Delete<TEntity, TKey>(TKey id)
            where TEntity : class
        {
            return _repository.Delete<TEntity, TKey>(id);
        }

        public virtual int Delete<TEntity, TKey>(TKey[] ids)
            where TEntity : class
        {
            return _repository.Delete<TEntity, TKey>(ids);
        }

        public virtual int Delete<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class
        {
            return _repository.Delete<TEntity>(GetPredicates<TEntity, TDto>(predicates));
        }

        public virtual async Task<int> DeleteAsync<TEntity, TKey>(TKey id)
            where TEntity : class
        {
            return await _repository.DeleteAsync<TEntity, TKey>(id);
        }

        public virtual async Task<int> DeleteAsync<TEntity, TKey>(TKey[] ids)
            where TEntity : class
        {
            return await _repository.DeleteAsync<TEntity, TKey>(ids);
        }

        public virtual async Task<int> DeleteAsync<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class
        {
            return await _repository.DeleteAsync<TEntity>(GetPredicates<TEntity, TDto>(predicates));
        }

        public virtual int Update<TEntity, TDto>(TDto dto, object id)
            where TEntity : class
            where TDto : class
        {
            var entity = _repository.Find<TEntity>(id);
            Mapper.Map<TDto, TEntity>(dto, entity);

            return _repository.Update<TEntity>(entity);
        }

        public virtual async Task<int> UpdateAsync<TEntity, TDto>(TDto dto, object id)
            where TEntity : class
            where TDto : class
        {
            var entity = await _repository.FindAsync<TEntity>(id);
            Mapper.Map<TDto, TEntity>(dto, entity);

            return await _repository.UpdateAsync<TEntity>(entity);
        }
        public virtual int ExecuteNonQuery(string sql, params object[] sqlParams)
        {
            return _repository.ExecuteNonQuery(sql, sqlParams);
        }
        public virtual void Dispose()
        {
            if (_repository != null)
            {
                _repository.Dispose();
                _repository = null;
            }
        }
        protected Expression<Func<TEntity, bool>>[] GetPredicates<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
        {
            return MappingHelper.GetMappedSelectors<TDto, TEntity, bool>(predicates).ToArray();
        }
    }
}