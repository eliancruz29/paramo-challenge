using Sat.Recruitment.Domain.Primitives;
using System.Linq;

namespace Sat.Recruitment.Infrastructure.Specifications
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> GetQuery<TEntity>(
            IQueryable<TEntity> inputQueryable,
            Specification<TEntity> specification)
            where TEntity : Entity
        {
            IQueryable<TEntity> queryable = inputQueryable;

            if (specification.Criteria != null)
            {
                queryable = queryable.Where(specification.Criteria);
            }

            return queryable;
        }
    }
}
