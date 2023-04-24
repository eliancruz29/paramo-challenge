using AutoMapper;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Application.Contracts.DTOs;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Repositories;
using Sat.Recruitment.Domain.Resources;
using Sat.Recruitment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Abstractions
{
    public sealed class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWOrk;
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;

        public UserService(
            IMapper mapper,
            IUnitOfWork unitOfWOrk,
            ILogger<UserService> logger,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWOrk = unitOfWOrk;
            _userRepository = userRepository;
        }

        public async Task<Result<UserDto>> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await _userRepository.GetByEmailAsync(email, cancellationToken);

                if (null != user)
                {
                    return Result.Success(_mapper.Map<UserDto>(user));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return Result.Error(default(UserDto), UserMessages.User_003);
        }

        public async Task<Result<IEnumerable<UserDto>>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                var users = await _userRepository.GetByNameAsync(name, cancellationToken);

                if (null != users && users.Any())
                {
                    return Result.Success(_mapper.Map<IEnumerable<UserDto>>(users));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return Result.Error(default(IEnumerable<UserDto>), UserMessages.User_003);
        }

        public async Task<Result<Guid>> CreateUserAsync(UserDto user, CancellationToken cancellationToken = default)
        {
            try
            {
                var newUser = User.Create(
                    user.Name,
                    user.Email,
                    user.Address,
                    user.Phone,
                    user.UserType,
                    user.Money);

                await _userRepository.AddAsync(newUser, cancellationToken);

                await _unitOfWOrk.SaveChangesAsync(cancellationToken);

                return Result.Success(newUser.Id, UserMessages.User_001);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                var innerException = ex.InnerException;

                while (innerException?.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }

                if (innerException.Message.Contains("IX_User_Email"))
                    return Result.Error(Guid.Empty, UserMessages.User_002);

                return Result.Error(Guid.Empty, UserMessages.User_004);
            }
        }
    }
}
