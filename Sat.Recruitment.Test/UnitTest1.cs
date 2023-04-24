using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Application.Abstractions;
using Sat.Recruitment.Application.Contracts.DTOs;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Resources;
using Sat.Recruitment.Domain.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        private Mock<IUserService> fakeUserServices = new Mock<IUserService>();

        // Arrange
        private readonly UserDto _mockNewUser = new UserDto()
        {
            Name = "TestName",
            Email = "Test@gmail.com",
            Address = "TestAddress",
            Phone = "TestPhone",
            UserType = UserType.Normal,
            Money = 50
        };

        public UnitTest1(){}

        [Fact]
        public async Task Creating_New_User_Success()
        {
            // Arrange
            var newId = Guid.NewGuid();
            var response = Result.Success(newId, UserMessages.User_001);

            fakeUserServices.Setup(s => s.CreateUserAsync(_mockNewUser, CancellationToken.None))
                .ReturnsAsync(response);

            var userController = new UsersController(fakeUserServices.Object);

            // Act
            var result = await userController.CreateUser(_mockNewUser, CancellationToken.None);

            // Assert
            var actionResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal($"users/{newId}", actionResult.Location);
            var valueResult = Assert.IsType<Result<Guid>>(actionResult.Value);
            Assert.Equal(UserMessages.User_001, valueResult.Message);
        }

        [Fact]
        public async Task Creating_New_User_Fail_Repeated_User()
        {
            // Arrange
            var newId = Guid.Empty;
            var response = Result.Error(newId, UserMessages.User_002);

            fakeUserServices.Setup(s => s.CreateUserAsync(_mockNewUser, CancellationToken.None))
                .ReturnsAsync(response);

            var userController = new UsersController(fakeUserServices.Object);

            // Act
            var result = await userController.CreateUser(_mockNewUser, CancellationToken.None);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var valueResult = Assert.IsType<Result<Guid>>(actionResult.Value);
            Assert.Equal(UserMessages.User_002, valueResult.Message);
        }
    }
}
