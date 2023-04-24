using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Infrastructure.Specifications
{
    internal class UserByEmailSpecification : Specification<User>
    {
        public UserByEmailSpecification(string email) : base(user => email == user.Email) { }
    }
}
