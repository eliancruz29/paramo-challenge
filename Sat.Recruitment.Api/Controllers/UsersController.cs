using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Application.Contracts.DTOs;
using Sat.Recruitment.Domain.Shared;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        //private readonly List<User> _users = new List<User>();
        public UsersController()
        {
        }

        [HttpPost]
        [Route("/create-user")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(200, Type = typeof(Result<UserDto>))]
        [ProducesResponseType(400, Type = typeof(Result))]
        public async Task<IActionResult> CreateUser([FromBody] UserDto data)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.Values.Select(
                    e => string.Join(", ", e.Errors.Select(m => m.ErrorMessage))));

                return BadRequest(Result.Error(data, errors));
            }

            return Ok(Result.Success(data, "User Created"));

            //var newUser = new User
            //{
            //    Name = name,
            //    Email = email,
            //    Address = address,
            //    Phone = phone,
            //    UserType = userType,
            //    Money = decimal.Parse(money)
            //};

            //var reader = ReadUsersFromFile();

            ////Normalize email
            //var aux = newUser.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            //var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            //aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            //newUser.Email = string.Join("@", new string[] { aux[0], aux[1] });

            //while (reader.Peek() >= 0)
            //{
            //    var line = reader.ReadLineAsync().Result;
            //    var user = new User
            //    {
            //        Name = line.Split(',')[0].ToString(),
            //        Email = line.Split(',')[1].ToString(),
            //        Phone = line.Split(',')[2].ToString(),
            //        Address = line.Split(',')[3].ToString(),
            //        UserType = line.Split(',')[4].ToString(),
            //        Money = decimal.Parse(line.Split(',')[5].ToString()),
            //    };
            //    _users.Add(user);
            //}
            //reader.Close();
            //try
            //{
            //    var isDuplicated = false;
            //    foreach (var user in _users)
            //    {
            //        if (user.Email == newUser.Email
            //            ||
            //            user.Phone == newUser.Phone)
            //        {
            //            isDuplicated = true;
            //        }
            //        else if (user.Name == newUser.Name)
            //        {
            //            if (user.Address == newUser.Address)
            //            {
            //                isDuplicated = true;
            //                throw new Exception("User is duplicated");
            //            }

            //        }
            //    }

            //    if (!isDuplicated)
            //    {
            //        Debug.WriteLine("User Created");

            //        return new Result()
            //        {
            //            IsSuccess = true,
            //            Errors = "User Created"
            //        };
            //    }
            //    else
            //    {
            //        Debug.WriteLine("The user is duplicated");

            //        return new Result()
            //        {
            //            IsSuccess = false,
            //            Errors = "The user is duplicated"
            //        };
            //    }
            //}
            //catch
            //{
            //    Debug.WriteLine("The user is duplicated");
            //    return new Result()
            //    {
            //        IsSuccess = false,
            //        Errors = "The user is duplicated"
            //    };
            //}

            //return new Result()
            //{
            //    IsSuccess = true,
            //    Errors = "User Created"
            //};
        }
    }
}
