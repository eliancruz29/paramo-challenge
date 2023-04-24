using Sat.Recruitment.Domain.Primitives;
using System;
using System.Linq.Expressions;

namespace Sat.Recruitment.Infrastructure.Specifications
{
    public abstract class Specification<TEntity> where TEntity : Entity
    {
        protected Specification(Expression<Func<TEntity, bool>> criteria) => Criteria = criteria;

        public Expression<Func<TEntity, bool>> Criteria { get; }
    }
}
