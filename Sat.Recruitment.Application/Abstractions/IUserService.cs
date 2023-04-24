using Sat.Recruitment.Application.Contracts.DTOs;
using Sat.Recruitment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Abstractions
{
    public interface IUserService
    {
        Task<Result<UserDto>> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

        Task<Result<IEnumerable<UserDto>>> GetByNameAsync(string name, CancellationToken cancellationToken = default);

        Task<Result<Guid>> CreateUserAsync(UserDto user, CancellationToken cancellationToken = default);
    }
}
