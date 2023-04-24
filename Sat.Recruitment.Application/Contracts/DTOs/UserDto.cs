using Sat.Recruitment.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sat.Recruitment.Application.Contracts.DTOs
{
    public class UserDto
    {
        public UserDto() { }

        [Required(ErrorMessage = "The name is required")]
        [JsonPropertyName("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The email is required")]
        [EmailAddress]
        [JsonPropertyName("email")]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The address is required")]
        [JsonPropertyName("address")]
        [MaxLength(250)]
        public string Address { get; set; }

        [Required(ErrorMessage = "The phone is required")]
        [JsonPropertyName("phone")]
        [MaxLength(25)]
        public string Phone { get; set; }

        [JsonPropertyName("userType")]
        public UserType UserType { get; set; }

        [JsonPropertyName("money")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Money { get; set; }
    }
}
