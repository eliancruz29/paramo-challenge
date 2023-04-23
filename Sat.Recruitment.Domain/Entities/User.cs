using System;

namespace Sat.Recruitment.Domain.Entities
{
    internal sealed class User : Entity
    {
        private User(
            Guid id,
            string name,
            string email,
            string address,
            string phone,
            UserType userType,
            decimal money)
            : base (id)
        {
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            UserType = userType;
            Money = money;
        }

        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public UserType UserType { get; private set; }
        public decimal Money { get; private set; }

        public static User Create(
            string name,
            string email,
            string address,
            string phone,
            UserType userType,
            decimal money)
        {
            var newUser = new User(
                Guid.NewGuid(),
                name,
                email,
                address,
                phone,
                userType,
                money);

            if (UserType.Normal == newUser.UserType)
            {
                decimal percentage = 1;
                
                // If new user is normal and has more than USD100
                if (money > 100)
                {
                    percentage += Convert.ToDecimal(0.12);
                }
                else if (money < 100 && money > 10)
                {
                    percentage += Convert.ToDecimal(0.8);    
                }
                
                newUser.Money *= percentage;
            }
            else if (UserType.SuperUser == newUser.UserType)
            {
                if (money > 100)
                {
                    var percentage = Convert.ToDecimal(1.20);
                    newUser.Money *= percentage;
                }
            }
            else if (UserType.Premium == newUser.UserType)
            {
                if (money > 100)
                {
                    newUser.Money *= 2;
                }
            }
            else
            {
                // TODO Exceptions
            }

            return newUser;
        }
    }
}
