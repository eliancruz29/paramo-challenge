using Sat.Recruitment.Application.Contracts.DTOs;
using Sat.Recruitment.Domain.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Abstractions
{
    public interface IUserService
    {
        Task<Result<Guid>> CreateUserAsync(UserDto user, CancellationToken cancellationToken = default);
    }
}
