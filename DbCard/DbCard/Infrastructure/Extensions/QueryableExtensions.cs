using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using DbCard.Domain;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using System.Text;
using DbCard.Infrastructure.Models;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;

namespace DbCard.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        public async static Task<IEnumerable<TDto>> CreateScrollPaginatedResultAsync<TEntity, TDto>(
            this IQueryable<TEntity> query,
            PagedRequest scrollRequest,
            IMapper mapper,
            Expression<Func<TEntity, bool>> optionalPredicate = null)
              where TEntity : Entity<long>
              where TDto : class
        {
            query = query.ApplyFilters(scrollRequest, optionalPredicate);

            query = query.Sort(scrollRequest);

            query = query.Paginate(scrollRequest);

            var projectionResult = query.ProjectTo<TDto>(mapper.ConfigurationProvider);

            var listResult = await projectionResult.ToListAsync();

            return listResult;
        }

        public async static Task<PaginatedResult<TDto>> CreatePaginatedResultAsync<TEntity, TDto>(
            this IQueryable<TEntity> query, 
            PagedRequest pagedRequest, 
            IMapper mapper, 
            Expression<Func<TEntity, bool>> optionalPredicate = null)
              where TEntity : Entity<long>
              where TDto : class
        {
            query = query.ApplyFilters(pagedRequest, optionalPredicate);

            var total = await query.CountAsync();

            query = query.Sort(pagedRequest);

            query = query.Paginate(pagedRequest);

            var projectionResult = query.ProjectTo<TDto>(mapper.ConfigurationProvider);

            var listResult = await projectionResult.ToListAsync();

            return new PaginatedResult<TDto>()
            {
                Items = listResult,
                PageSize = pagedRequest.PageSize,
                PageIndex = pagedRequest.PageIndex,
                Total = total
            };
        }

        private static IQueryable<T> Paginate<T>(this IQueryable<T> query, PagedRequest pagedRequest)
        {
            var entities = query.Skip((pagedRequest.PageIndex) * pagedRequest.PageSize).Take(pagedRequest.PageSize);
            return entities;
        }

        private static IQueryable<T> Sort<T>(this IQueryable<T> query, PagedRequest pagedRequest)
        {
            if (!string.IsNullOrWhiteSpace(pagedRequest.ColumnNameForSorting))
            {
                query = query.OrderBy(pagedRequest.ColumnNameForSorting + " " + pagedRequest.SortDirection);
            }
            return query;
        }

        private static IQueryable<T> ApplyFilters<T>(
            this IQueryable<T> query, 
            PagedRequest pagedRequest, 
            Expression<Func<T, bool>> optionalPredicate = null)
        {
            if (optionalPredicate != null) query = query.Where(optionalPredicate);

            var predicate = new StringBuilder();
            var requestFilters = pagedRequest.RequestFilters;

            for (int i = 0; i < requestFilters.Filters.Count; i++)
            {
                if (i > 0)
                {
                    predicate.Append($" {requestFilters.LogicalOperator} ");
                }
                predicate.Append(requestFilters.Filters[i].Path + $".{nameof(string.Contains)}(@{i})");
            }

            if (requestFilters.Filters.Any())
            {
                var propertyValues = requestFilters.Filters.Select(filter => filter.Value).ToArray();

                query = query.Where(predicate.ToString(), propertyValues);
            }

            return query;
        }
    }
}
