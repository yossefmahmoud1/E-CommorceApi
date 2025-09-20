using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Domain_Layer.Contracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Domain_Layer.Models.Producr;
namespace Persistence
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery

            
            <TEntity, TKey>  (IQueryable<TEntity> InputQuery, ISpecification<TEntity, TKey> specifications)where TEntity : BaseEntity<TKey>
        {
            var Query = InputQuery;

            if (specifications.Crietria is not null)
            {
                Query = Query.Where(specifications.Crietria);
            }
            if (specifications.OrderBy is not null)
            {
                Query = Query.OrderBy(specifications.OrderBy);
            }
            if (specifications.OrderByDescending is not null)
            {
                Query = Query.OrderByDescending(specifications.OrderByDescending);
            }

            if (specifications.IncludeExpressions is not null && specifications.IncludeExpressions.Count > 0)
            {
                Query = specifications.IncludeExpressions.Aggregate(seed: Query, func: (CurrentQuery, IncludeExp) => CurrentQuery.Include(navigationPropertyPath: IncludeExp));
            }

            if (specifications.IsPaginate )
            {
                Query = Query.Skip(specifications.Skip).Take(specifications.Take);
            }
            return Query;
        }
    }
}
