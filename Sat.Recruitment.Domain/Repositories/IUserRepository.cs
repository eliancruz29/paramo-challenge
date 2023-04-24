using Sat.Recruitment.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

        Task<IEnumerable<User>> GetByNameAsync(string name, CancellationToken cancellationToken = default);

        Task AddAsync(User user, CancellationToken cancellationToken = default);

        void Remove(User user);
    }
}
