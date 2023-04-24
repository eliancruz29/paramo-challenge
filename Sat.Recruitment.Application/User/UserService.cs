using Sat.Recruitment.Application.Contracts.DTOs;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Repositories;
using Sat.Recruitment.Domain.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Abstractions
{
    public sealed class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWOrk;
        private readonly IUserRepository _userRepository;

        public UserService(
            IUnitOfWork unitOfWOrk,
            IUserRepository userRepository)
        {
            _unitOfWOrk = unitOfWOrk;
            _userRepository = userRepository;
        }

        public async Task<Result> CreateUserAsync(UserDto user, CancellationToken cancellationToken = default)
        {
            try
            {
                var newUser = User.Create(
                    user.Name,
                    user.Email,
                    user.Address,
                    user.Phone,
                    user.UserType,
                    user.Money
                    );

                await _userRepository.AddAsync(newUser, cancellationToken);

                await _unitOfWOrk.SaveChangesAsync(cancellationToken);

                return Result.Success(newUser.Id, "User Created");
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException;

                while (innerException?.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }

                if (innerException.Message.Contains("IX_User_Email"))
                    return Result.Error("The user is duplicated");

                throw;
            }
        }
    }
}
