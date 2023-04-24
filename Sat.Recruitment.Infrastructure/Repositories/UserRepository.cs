using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Repositories;
using Sat.Recruitment.Infrastructure.Specifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infrastructure.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByEmailAsync(
            string email,
            CancellationToken cancellationToken = default) =>
            await ApplySpecification(new UserByEmailSpecification(email))
                    .FirstOrDefaultAsync(cancellationToken);

        public async Task<IEnumerable<User>> GetByNameAsync(
            string name,
            CancellationToken cancellationToken = default) =>
            await ApplySpecification(new UsersByNameSpecification(name))
                    .ToListAsync(cancellationToken);

        public async Task AddAsync(
            User user,
            CancellationToken cancellationToken = default) =>
            await _dbContext.Users.AddAsync(user, cancellationToken);
        

        private IQueryable<User> ApplySpecification(
            Specification<User> specification) =>
            SpecificationEvaluator.GetQuery(
                _dbContext.Users,
                specification);
    }
}
