using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Infrastructure.Specifications
{
    internal class UsersByNameSpecification : Specification<User>
    {
        public UsersByNameSpecification(string name) : base(user => name == user.Name) { }
    }
}
