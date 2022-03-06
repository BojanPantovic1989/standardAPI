using standardAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace standardAPI.Services
{
    public interface IUserService
    {
        UserDto? GetUser(string userName, string password);
    }
    public class UserService : IUserService
    {
        private static List<UserDto> _users => new List<UserDto>()
        {
            new UserDto("admin", "abc123")
        };

        public UserDto GetUser(string userName, string password)
        {
            return _users.FirstOrDefault(x => string.Equals(x.UserName, userName) && string.Equals(x.Password, password));
        }
    }
}
