using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Application.Abstractions;
using Sat.Recruitment.Application.Contracts.DTOs;
using Sat.Recruitment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading;
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

        [HttpGet("by-email")]
        [ProducesResponseType(200, Type = typeof(Result<UserDto>))]
        [ProducesResponseType(404, Type = typeof(Result))]
        public async Task<IActionResult> GetByEmail([FromQuery] string email, CancellationToken cancellationToken)
        {
            var result = await _userService.GetByEmailAsync(email, cancellationToken);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpGet("by-name")]
        [ProducesResponseType(200, Type = typeof(Result<IEnumerable<UserDto>>))]
        [ProducesResponseType(404, Type = typeof(Result))]
        public async Task<IActionResult> GetByName([FromQuery] string name, CancellationToken cancellationToken)
        {
            var result = await _userService.GetByNameAsync(name, cancellationToken);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpPost("create-user")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(201, Type = typeof(Result<Guid>))]
        [ProducesResponseType(400, Type = typeof(Result))]
        public async Task<IActionResult> CreateUser([FromBody] UserDto data, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.Values.Select(
                    e => string.Join(", ", e.Errors.Select(m => m.ErrorMessage))));

                return BadRequest(Result.Error(data, errors));
            }

            var result = await _userService.CreateUserAsync(data, cancellationToken);

            if (result.IsSuccess)
            {
                return Created($"users/{result.Value}", result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
