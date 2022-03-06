using System.ComponentModel.DataAnnotations;

namespace standardAPI.Models
{
    public class UserDto
    {
        public UserDto()
        {

        }

        public UserDto(string username, string password)
        {
            this.UserName = username;
            this.Password = password;
        }

        public string UserName { get; set; }
        
        public string Password { get; set; }
    }
}
