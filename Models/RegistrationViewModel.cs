using System.ComponentModel.DataAnnotations;

namespace CST350.Models
{
    public class RegistrationViewModel
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string firstname { get; set; }

        [Required]
        public string lastname { get; set; }

        [Required]
        public bool sex { get; set; }

        [Required]
        public int age { get; set; }

        [Required]
        public string state { get; set; }

        public RegistrationViewModel() { }

        public RegistrationViewModel
        (
            string username,
            string password,
            string firstname,
            string lastname,
            bool sex,
            int age,
            string state
        )
        {
            this.username = username;
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
            this.sex = sex;
            this.age = age;
            this.state = state;
        }
    }
}

