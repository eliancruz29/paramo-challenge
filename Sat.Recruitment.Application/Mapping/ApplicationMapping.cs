using AutoMapper;
using Sat.Recruitment.Application.Contracts.DTOs;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Application.Mapping
{
    internal class ApplicationMapping : Profile
    {
        public ApplicationMapping()
        {
            CreateMap<User, UserDto>();
        }
    }
}
