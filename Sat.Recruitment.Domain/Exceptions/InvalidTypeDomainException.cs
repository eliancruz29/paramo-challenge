namespace Sat.Recruitment.Domain.Exceptions
{
    internal sealed class InvalidTypeDomainException : DomainException
    {
        public InvalidTypeDomainException(string objName) : base(GenerateMessage(objName)) {}

        private static string GenerateMessage(string objName)
        {
            return $"The type of the {objName} is incorrect";
        }
    }
}
