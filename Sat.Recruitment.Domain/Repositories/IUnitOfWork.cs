using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
