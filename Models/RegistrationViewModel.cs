using System.ComponentModel.DataAnnotations;

namespace CST350.Models
{
    public class RegistrationViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public RegistrationViewModel ToEntity()
        {
            return new RegistrationViewModel
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Sex = this.Sex,
                Age = this.Age,
                State = this.State,
                EmailAddress = this.EmailAddress,
                Username = this.Username,
                Password = this.Password
            };
        }
    }
}

