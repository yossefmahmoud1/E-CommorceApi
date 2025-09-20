using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain_Layer.Contracts;
using Domain_Layer.Models.Producr;

namespace Domain_Layer.Specification
{
    public class BaseSpecifications<TEntity, Tkey> : ISpecification<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        public Expression<Func<TEntity, bool>>? Crietria { get; }
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new();
        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }
        public Expression<Func<TEntity, object>>? OrderByDescending { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPaginate { get; set; }

        protected BaseSpecifications()
        {
        }

        protected BaseSpecifications(Expression<Func<TEntity, bool>> crietria)
        {
            Crietria = crietria;
        }
    }
}