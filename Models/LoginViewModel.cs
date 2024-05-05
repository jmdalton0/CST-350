using System.ComponentModel.DataAnnotations;


namespace CST350.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public LoginViewModel ToEntity()
        {
            return new LoginViewModel
            {
                UserName = this.UserName,
                Password = this.Password
            };
        }
    }
}
