using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Application.Abstractions;
using Sat.Recruitment.Application.Contracts.DTOs;
using Sat.Recruitment.Domain.Shared;
using System;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(
            IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/create-user")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(201, Type = typeof(Result<Guid>))]
        [ProducesResponseType(400, Type = typeof(Result))]
        public async Task<IActionResult> CreateUser([FromBody] UserDto data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = string.Join(", ", ModelState.Values.Select(
                        e => string.Join(", ", e.Errors.Select(m => m.ErrorMessage))));

                    return BadRequest(Result.Error(data, errors));
                }

                var result = await _userService.CreateUserAsync(data);

                if (result.IsSuccess)
                {
                    return Created($"{nameof(UsersController)}/{result.Value}", result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                // TODO Log errors
                return BadRequest(Result.Error(ex.Message));
            }
        }
    }
}
