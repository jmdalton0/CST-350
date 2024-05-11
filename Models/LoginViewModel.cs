using System.ComponentModel.DataAnnotations;


namespace CST350.Models
{
    public class LoginViewModel
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        public LoginViewModel() { }

        public LoginViewModel(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
